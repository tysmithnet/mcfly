CREATE TABLE [dbo].[frame]
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
    
    CONSTRAINT [CK_frame_pos_hi] CHECK (pos_hi >= 0),
    CONSTRAINT [CK_frame_pos_lo] CHECK (pos_lo >= 0),
    CONSTRAINT [CK_frame_thread_id] CHECK (thread_id >= 0), 
    CONSTRAINT [PK_frame] PRIMARY KEY ([pos_hi], [thread_id], [pos_lo]),
)
