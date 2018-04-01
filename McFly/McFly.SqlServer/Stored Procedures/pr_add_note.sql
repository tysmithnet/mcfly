CREATE PROCEDURE [dbo].[pr_add_note] @pos_hi INT,
	@pos_lo INT,
	@thread_ids tt_int readonly,
	@text TEXT
AS
BEGIN TRANSACTION

INSERT INTO note
VALUES (
	GETUTCDATE(),
	@text
	)

DECLARE @note_id INT = @@identity

INSERT INTO frame_note
SELECT @pos_hi,
	@pos_lo,
	value0,
	@note_id
FROM @thread_ids

COMMIT TRANSACTION

RETURN 0
