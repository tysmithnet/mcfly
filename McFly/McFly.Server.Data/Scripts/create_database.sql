/*
Meta data about the trace
*/
CREATE TABLE trace_info (
 lock CHAR(1) NOT NULL DEFAULT 'X',
 start_pos_hi INTEGER NOT NULL,
 start_pos_lo INTEGER NOT NULL,
 end_pos_hi INTEGER NOT NULL,
 end_pos_lo INTEGER NOT NULL,
 CONSTRAINT pk_trace_info PRIMARY KEY (Lock),
 CONSTRAINT ck_trace_info_lock CHECK (Lock = 'X')
 );
GO

CREATE TABLE frame (
 pos_hi INTEGER NOT NULL,
 pos_lo INTEGER NOT NULL,
 CONSTRAINT pk_frame PRIMARY KEY (
  pos_hi,
  pos_lo
  ),
 CONSTRAINT ch_frame_address CHECK (pos_hi >= 0 AND pos_lo >= 0)
 )
GO

/*  
A process can have many threads in it, and so at any one instant in time there are potentially many
threads running. This table captures the state of a particular thread at a particular instant in time.
Note that the values here are the values BEFORE the instruction is executed.  
 */
CREATE TABLE frame_thread (
 pos_hi INTEGER NOT NULL,
 pos_lo INTEGER NOT NULL,
 thread_id INTEGER NOT NULL,
 rax BIGINT,
 rbx BIGINT,
 rcx BIGINT,
 rdx BIGINT,
 opcode_nmemonic VARCHAR(20),
 CONSTRAINT pk_frame_thread PRIMARY KEY (
  pos_hi,
  pos_lo,
  thread_id
  ),
 CONSTRAINT fk_frame_thread_frame FOREIGN KEY (
  pos_hi,
  pos_lo
  ) REFERENCES frame(pos_hi, pos_lo)
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
 CONSTRAINT fk_frame_memory_frame FOREIGN KEY (
  pos_hi,
  pos_lo
  ) REFERENCES frame(pos_hi, pos_lo),
 CONSTRAINT ck_frame_memory_address CHECK (start_address <= end_address AND start_address >= 0 AND LEN(memory) = end_address - start_address)
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
 @rax BIGINT = NULL,
 @rbx BIGINT = NULL,
 @rcx BIGINT = NULL,
 @rdx BIGINT = NULL,
 @opcode_nmemonic VARCHAR(20) = NULL,
 @disassembly_note VARCHAR(250) = NULL
 )
AS
BEGIN
 IF NOT EXISTS (
   SELECT 1
   FROM frame
   WHERE pos_hi = @pos_hi AND pos_lo = @pos_lo
   )
 BEGIN
  INSERT INTO frame
  VALUES (
   @pos_hi,
   @pos_lo
   )
 END

 MERGE frame_thread AS d
 USING (
  SELECT @pos_hi AS pos_hi,
   @pos_lo AS pos_lo,
   @thread_id AS thread_id,
   @rax AS rax,
   @rbx AS rbx,
   @rcx AS rcx,
   @rdx AS rdx,
   @opcode_nmemonic AS opcode_nmemonic
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
    opcode_nmemonic
    )
   VALUES (
    @pos_hi,
    @pos_lo,
    @thread_id,
    @rax,
    @rbx,
    @rcx,
    @rdx,
    @opcode_nmemonic
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
    d.opcode_nmemonic = COALESCE(@opcode_nmemonic, s.opcode_nmemonic);
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


