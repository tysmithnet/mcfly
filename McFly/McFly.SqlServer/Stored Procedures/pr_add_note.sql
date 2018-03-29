CREATE PROCEDURE [dbo].[pr_add_note] @pos_hi    INT, 
                                     @pos_lo    INT, 
                                     @thread_id INT = NULL, 
                                     @text      TEXT 
AS 
    DECLARE @note_id INT; 

    IF @thread_id IS NULL 
      BEGIN 
          BEGIN TRAN 

          INSERT INTO note 
          VALUES      (Getutcdate(), 
                       @text) 

          SET @note_id = @@IDENTITY 

          INSERT INTO frame_note 
          SELECT pos_hi, 
                 pos_lo, 
                 thread_id, 
                 @note_id AS note_id 
          FROM   frame 
          WHERE  pos_hi = @pos_hi 
                 AND pos_lo = @pos_lo 

          COMMIT TRAN 
      END 
    ELSE 
      BEGIN 
          BEGIN TRAN 

          INSERT INTO note 
          VALUES      (Getutcdate(), 
                       @text) 

          SET @note_id = @@IDENTITY 

          INSERT INTO frame_note 
          SELECT pos_hi, 
                 pos_lo, 
                 @thread_id AS thread_id, 
                 @note_id   AS note_id 
          FROM   frame 
          WHERE  pos_hi = @pos_hi 
                 AND pos_lo = @pos_lo 

          COMMIT TRAN 
      END 

    RETURN 0 