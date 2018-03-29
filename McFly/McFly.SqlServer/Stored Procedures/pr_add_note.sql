CREATE PROCEDURE [dbo].[pr_add_note] @pos_hi    INT, 
                                     @pos_lo    INT, 
                                     @thread_ids tt_int readonly,
                                     @text      TEXT 
AS 
BEGIN TRAN

    
    INSERT INTO note VALUES (GETUTCDATE(), @text)

    declare @note_id int = @@identity

    insert into frame_note
    select @pos_hi, @pos_lo, value0, @text from @thread_ids
    
COMMIT TRAN
RETURN 0 