CREATE TYPE [dbo].[tt_frame] AS TABLE
(
    [pos_hi] INT NOT NULL, 
    [pos_lo] INT NOT NULL, 
    [thread_id] INT NOT NULL, 
    [rax] BIGINT NULL, 
    [rbx] BIGINT NULL, 
    [rcx] BIGINT NULL, 
    [rdx] BIGINT NULL, 
    [opcode] VARBINARY(32) NULL,
    [opcode_mnemonic] VARCHAR(32) NULL, 
    [disassembly_note] VARCHAR(256) NULL,

    PRIMARY KEY (pos_hi, pos_lo, thread_id)
);

GO
