CREATE PROCEDURE [dbo].[pr_upsert_frames]
    @frames tt_frame READONLY
AS
    MERGE frame AS T
    USING @frames AS S
    ON (T.pos_hi = S.pos_hi AND T.pos_lo = S.pos_lo AND T.thread_id = S.thread_id)
    WHEN NOT MATCHED BY TARGET THEN 
        INSERT VALUES (S.pos_hi, S.pos_lo, S.thread_id, S.rax, S.rbx, S.rcx, S.rdx, S.opcode_nmemonic, S.disassembly_note)
    WHEN MATCHED THEN
        UPDATE 
            SET T.rax = COALESCE(T.rax, S.rax),
            T.rax = COALESCE(T.rax, S.rax),
            T.rbx = COALESCE(T.rbx, S.rbx),
            T.rcx = COALESCE(T.rcx, S.rcx),
            T.rdx = COALESCE(T.rdx, S.rdx),
            T.opcode_mnemonic = COALESCE(T.opcode_mnemonic, S.opcode_mnemonic);   
    
RETURN 0
