CREATE PROCEDURE [dbo].[pr_upsert_frames] @frames      TT_FRAME readonly, 
                                          @stackFrames TT_STACKFRAME readonly 
AS 
    MERGE frame AS T 
    using @frames AS S 
    ON ( T.pos_hi = s.pos_hi 
         AND T.pos_lo = s.pos_lo 
         AND T.thread_id = s.thread_id ) 
    WHEN NOT matched BY target THEN 
      INSERT 
      VALUES (S.pos_hi, 
              S.pos_lo, 
              S.thread_id, 
              S.rax, 
              S.rbx, 
              S.rcx, 
              S.rdx, 
              S.opcode, 
              S.opcode_mnemonic, 
              S.disassembly_note) 
    WHEN matched THEN 
      UPDATE SET T.rax = COALESCE(S.rax, T.rax), 
                 T.rbx = COALESCE(S.rbx, T.rbx), 
                 T.rcx = COALESCE(S.rcx, T.rcx), 
                 T.rdx = COALESCE(S.rdx, T.rdx), 
                 T.opcode = COALESCE(S.opcode, T.opcode), 
                 T.opcode_mnemonic = COALESCE(S.opcode_mnemonic, 
                                     T.opcode_mnemonic), 
                 T.disassembly_note = COALESCE(S.disassembly_note, 
                                      T.disassembly_note); 

    MERGE stackframe AS T 
    using @stackFrames AS S 
    ON ( T.pos_hi = s.pos_hi 
         AND T.pos_lo = s.pos_lo 
         AND T.thread_id = s.thread_id 
         AND T.depth = s.depth ) 
    WHEN NOT matched BY target THEN 
      INSERT 
      VALUES (S.pos_hi, 
              S.pos_lo, 
              S.thread_id, 
              S.depth, 
              S.stack_pointer, 
              S.return_address, 
              S.module, 
              S.function_name, 
              S.offset) 
    WHEN matched THEN 
      UPDATE SET T.stack_pointer = COALESCE(S.stack_pointer, T.stack_pointer), 
                 T.return_address = COALESCE(S.stack_pointer, T.return_address), 
                 T.function_name = COALESCE(S.stack_pointer, T.function_name), 
                 T.offset = COALESCE(S.stack_pointer, T.offset); 

    RETURN 0 