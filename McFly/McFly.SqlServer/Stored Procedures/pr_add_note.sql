CREATE PROCEDURE [dbo].[pr_add_note]
    @pos_hi int,
    @pos_lo int,
    @thread_id int,
    @text Text
AS
    insert into note values(@pos_hi, @pos_lo, @thread_id, getutcdate(), @text)
RETURN 0
