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
 /* High portion of the position, e.g. 1F0:2D => 1F0 */
 pos_hi INTEGER NOT NULL,
 /* Low portion of the position, e.g. 1F0:2D => 2D */
 pos_lo INTEGER NOT NULL,
 /* Thread id */
 thread_id INTEGER NOT NULL,  
 /* Value of rax */
 rax BINARY(64),
 /* Value of rbx */
 rbx BINARY(64),
 /* Value of rcx */
 rcx BINARY(64),
 /* Value of rdx */
 rdx BINARY(64),
 /* Value of rsi */
 rsi BINARY(64),
 /* Value of rdi */
 rdi BINARY(64),
 /* Value of rsp */
 rsp BINARY(64),
 /* Value of rbp */
 rbp BINARY(64),
 /* Value of rip */
 rip BINARY(64),
 /* Value of efl */
 efl BINARY(32),
 /* Value of cs */
 cs BINARY(64),
 /* Value of ds */
 ds BINARY(64),
 /* Value of es */
 es BINARY(64),
 /* Value of fs */
 fs BINARY(64),
 /* Value of gs */
 gs BINARY(64),
 /* Value of ss */
 ss BINARY(64),
 /* Value of r8 */
 r8 BINARY(64),
 /* Value of r9 */
 r9 BINARY(64),
 /* Value of r10 */
 r10 BINARY(64),
 /* Value of r11 */
 r11 BINARY(64),
 /* Value of r12 */
 r12 BINARY(64),
 /* Value of r13 */
 r13 BINARY(64),
 /* Value of r14 */
 r14 BINARY(64),
 /* Value of r15 */
 r15 BINARY(64),
 /* Value of dr0 */
 dr0 BINARY(64),
 /* Value of dr1 */
 dr1 BINARY(64),
 /* Value of dr2 */
 dr2 BINARY(64),
 /* Value of dr3 */
 dr3 BINARY(64),
 /* Value of dr6 */
 dr6 BINARY(64),
 /* Value of dr7 */
 dr7 BINARY(64),
 /* Value of exfrom */
 exfrom BINARY(64),
 /* Value of exto */
 exto BINARY(64),
 /* Value of brfrom */
 brfrom BINARY(64),
 /* Value of brto */
 brto BINARY(64),
 /* ret, call, mov, sub, etc */
 opcode_nmemonic TEXT,
 /* Address of the current instruction */
 code_address INTEGER,
 /* Module name for the current instruction */
 module VARCHAR(250),
 /* Function name for the current instruction */
 [function] VARCHAR(250),
 /* Function offset for the current instruction */
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
 @rsi BINARY(64) = NULL,
 @rdi BINARY(64) = NULL,
 @rsp BINARY(64) = NULL,
 @rbp BINARY(64) = NULL,
 @rip BINARY(64) = NULL,
 @efl BINARY(64) = NULL,
 @cs BINARY(64) = NULL,
 @ds BINARY(64) = NULL,
 @es BINARY(64) = NULL,
 @fs BINARY(64) = NULL,
 @gs BINARY(64) = NULL,
 @ss BINARY(64) = NULL,
 @r8 BINARY(64) = NULL,
 @r9 BINARY(64) = NULL,
 @r10 BINARY(64) = NULL,
 @r11 BINARY(64) = NULL,
 @r12 BINARY(64) = NULL,
 @r13 BINARY(64) = NULL,
 @r14 BINARY(64) = NULL,
 @r15 BINARY(64) = NULL,
 @dr0 BINARY(64) = NULL,
 @dr1 BINARY(64) = NULL,
 @dr2 BINARY(64) = NULL,
 @dr3 BINARY(64) = NULL,
 @dr6 BINARY(64) = NULL,
 @dr7 BINARY(64) = NULL,
 @exfrom BINARY(64) = NULL,
 @exto BINARY(64) = NULL,
 @brfrom BINARY(64) = NULL,
 @brto BINARY(64) = NULL,
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
   @rsi AS rsi,
   @rdi AS rdi,
   @rsp AS rsp,
   @rbp AS rbp,
   @rip AS rip,
   @efl AS efl,
   @cs AS cs,
   @ds AS ds,
   @es AS es,
   @fs AS fs,
   @gs AS gs,
   @ss AS ss,
   @r8 AS r8,
   @r9 AS r9,
   @r10 AS r10,
   @r11 AS r11,
   @r12 AS r12,
   @r13 AS r13,
   @r14 AS r14,
   @r15 AS r15,
   @dr0 AS dr0,
   @dr1 AS dr1,
   @dr2 AS dr2,
   @dr3 AS dr3,
   @dr6 AS dr6,
   @dr7 AS dr7,
   @exfrom AS exfrom,
   @exto AS exto,
   @brfrom AS brfrom,
   @brto AS brto,
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
    rsi,
    rdi,
    rsp,
    rbp,
    rip,
    efl,
    cs,
    ds,
    es,
    fs,
    gs,
    ss,
    r8,
    r9,
    r10,
    r11,
    r12,
    r13,
    r14,
    r15,
    dr0,
    dr1,
    dr2,
    dr3,
    dr6,
    dr7,
    exfrom,
    exto,
    brfrom,
    brto,
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
    @rsi,
    @rdi,
    @rsp,
    @rbp,
    @rip,
    @efl,
    @cs,
    @ds,
    @es,
    @fs,
    @gs,
    @ss,
    @r8,
    @r9,
    @r10,
    @r11,
    @r12,
    @r13,
    @r14,
    @r15,
    @dr0,
    @dr1,
    @dr2,
    @dr3,
    @dr6,
    @dr7,
    @exfrom,
    @exto,
    @brfrom,
    @brto,
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
    d.rsi = COALESCE(@rsi, s.rsi),
    d.rdi = COALESCE(@rdi, s.rdi),
    d.rsp = COALESCE(@rsp, s.rsp),
    d.rbp = COALESCE(@rbp, s.rbp),
    d.rip = COALESCE(@rip, s.rip),
    d.efl = COALESCE(@efl, s.efl),
    d.cs = COALESCE(@cs, s.cs),
    d.ds = COALESCE(@ds, s.ds),
    d.es = COALESCE(@es, s.es),
    d.fs = COALESCE(@fs, s.fs),
    d.gs = COALESCE(@gs, s.gs),
    d.ss = COALESCE(@ss, s.ss),
    d.r8 = COALESCE(@r8, s.r8),
    d.r9 = COALESCE(@r9, s.r9),
    d.r10 = COALESCE(@r10, s.r10),
    d.r11 = COALESCE(@r11, s.r11),
    d.r12 = COALESCE(@r12, s.r12),
    d.r13 = COALESCE(@r13, s.r13),
    d.r14 = COALESCE(@r14, s.r14),
    d.r15 = COALESCE(@r15, s.r15),
    d.dr0 = COALESCE(@dr0, s.dr0),
    d.dr1 = COALESCE(@dr1, s.dr1),
    d.dr2 = COALESCE(@dr2, s.dr2),
    d.dr3 = COALESCE(@dr3, s.dr3),
    d.dr6 = COALESCE(@dr6, s.dr6),
    d.dr7 = COALESCE(@dr7, s.dr7),
    d.exfrom = COALESCE(@exfrom, s.exfrom),
    d.exto = COALESCE(@exto, s.exto),
    d.brfrom = COALESCE(@brfrom, s.brfrom),
    d.brto = COALESCE(@brto, s.brto),
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