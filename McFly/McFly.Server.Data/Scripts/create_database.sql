/*
Meta data about the trace
*/
CREATE TABLE trace_info (
    lock CHAR(1) NOT NULL DEFAULT 'X',
    /* High portion of the position, e.g. 1F0:2D => 1F0 */
    start_pos_hi INTEGER NOT NULL,
    /* Low portion of the position, e.g. 1F0:2D => 2D */
    start_pos_lo INTEGER NOT NULL,
    /* High portion of the position, e.g. 1F0:2D => 1F0 */
    end_pos_hi INTEGER NOT NULL,
    /* Low portion of the position, e.g. 1F0:2D => 2D */
    end_pos_lo INTEGER NOT NULL,
    constraint pk_trace_info PRIMARY KEY (Lock),
    constraint ck_trace_info_lock CHECK (Lock='X')
);

GO

/*  
A process can have many threads in it, and so at any one instant in time there are potentially many
threads running. This table captures the state of a particular thread at a particular instant in time.
Note that the values here are the values BEFORE the instruction is executed.  
 */
CREATE TABLE frame (
 pos_hi INTEGER NOT NULL,
 pos_lo INTEGER NOT NULL,
 thread_id INTEGER NOT NULL,  
 rax BINARY(64),
 rbx BINARY(64),
 rcx BINARY(64),
 rdx BINARY(64),
 opcode_nmemonic TEXT,
 code_address INTEGER,
 module VARCHAR(250),
 [function] VARCHAR(250),
 function_offset INTEGER,
 PRIMARY KEY (
  pos_hi,
  pos_lo,
  thread_id
  )
 );

GO

/*
A note is a human readable comment
A single note can be applied to many frames, a single frame can have many notes
*/
CREATE TABLE note (
 note_id INT PRIMARY KEY IDENTITY(1, 1),
 content TEXT NOT NULL
 );

GO

/*
Linking table for frames and notes
*/
CREATE TABLE frame_note (
 pos_hi INT,
 pos_lo INT,
 thread_id INT,
 note_id INT,
 CONSTRAINT pk_frame_note PRIMARY KEY (
  pos_hi,
  pos_lo,
  thread_id,
  note_id
  )
 );

GO

CREATE TABLE frame_memory (
    pos_hi INT NOT NULL,
    pos_lo INT NOT NULL,
    start_address INT NOT NULL,
    end_address INT NOT NULL,
    memory VARBINARY(max) NOT NULL,

    CONSTRAINT fk_frame_memory_frame FOREIGN KEY (pos_hi, pos_lo) REFERENCES frame(pos_hi,pos_lo),
    CONSTRAINT ck_frame_memory_address CHECK (
		start_address <= end_address AND 
		start_address >= 0 AND
		LEN(memory) = end_address - start_address) 
);

GO

/*
Upserts a frame
If you pass null as any nullable value, the value already existing in the table will remain
*/
CREATE PROCEDURE pr_upsert_frame (
 @pos_hi INTEGER,
 @pos_lo INTEGER,
 @thread_id INTEGER,
 @rax BINARY(64) = NULL,
 @rbx BINARY(64) = NULL,
 @rcx BINARY(64) = NULL,
 @rdx BINARY(64) = NULL,
 @opcode_nmemonic TEXT = NULL,
 @code_address INTEGER = NULL,
 @module VARCHAR(250) = NULL,
 @function VARCHAR(250) = NULL,
 @function_offset INTEGER = NULL
 )
AS
BEGIN
 MERGE frame AS d
 USING (
  SELECT @pos_hi AS pos_hi,
   @pos_lo AS pos_lo,
   @thread_id AS thread_id,
   @rax AS rax,
   @rbx AS rbx,
   @rcx AS rcx,
   @rdx AS rdx,
   @opcode_nmemonic AS opcode_nmemonic,
   @code_address AS code_address,
   @module AS module,
   @function AS [function],
   @function_offset AS function_offset
  ) AS s
  ON s.pos_hi = d.pos_hi AND s.pos_lo = d.pos_lo AND s.thread_id = d.thread_id
 WHEN NOT MATCHED BY TARGET
  THEN
   INSERT (
    pos_hi,
    pos_lo,
    thread_id,
    rax,
    rbx,
    rcx,
    rdx,
    opcode_nmemonic,
    code_address,
    module,
    [function],
    function_offset
    )
   VALUES (
    @pos_hi,
    @pos_lo,
    @thread_id,
    @rax,
    @rbx,
    @rcx,
    @rdx,
    @opcode_nmemonic,
    @code_address,
    @module,
    @function,
    @function_offset
    )
 WHEN MATCHED
  THEN
   UPDATE
   SET d.pos_hi = COALESCE(@pos_hi, s.pos_hi),
    d.pos_lo = COALESCE(@pos_lo, s.pos_lo),
    d.thread_id = COALESCE(@thread_id, s.thread_id),
    d.rax = COALESCE(@rax, s.rax),
    d.rbx = COALESCE(@rbx, s.rbx),
    d.rcx = COALESCE(@rcx, s.rcx),
    d.rdx = COALESCE(@rdx, s.rdx),
    d.opcode_nmemonic = COALESCE(@opcode_nmemonic, s.opcode_nmemonic),
    d.code_address = COALESCE(@code_address, s.code_address),
    d.module = COALESCE(@module, s.module),
    d.[function] = COALESCE(@function, s.[function]),
    d.function_offset = COALESCE(@function_offset, s.function_offset);
END

GO

/*
Add a note, and optionally assign it to a frame
*/
CREATE PROCEDURE pr_add_note (
 @content TEXT,
 @pos_hi INT = NULL,
 @pos_lo INT = NULL,
 @thread_id INT = NULL
 )
AS
BEGIN
 INSERT INTO note (content)
 VALUES (@content)

 IF @pos_hi IS NOT NULL AND @pos_lo IS NOT NULL AND @thread_id IS NOT NULL
 BEGIN
  INSERT INTO frame_note
  VALUES (
   @pos_hi,
   @pos_lo,
   @thread_id,
   @@IDENTITY
   )
 END
END

GO