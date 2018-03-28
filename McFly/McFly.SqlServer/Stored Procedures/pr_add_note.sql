CREATE PROCEDURE [dbo].[Pr_add_note] @pos_hi    INT, 
                                     @pos_lo    INT, 
                                     @thread_id INT = NULL, 
                                     @text      TEXT 
AS 
    IF @thread_id IS NULL 
      BEGIN 
          BEGIN TRAN 

          INSERT INTO note 
          VALUES      (@text) 

          SELECT pos_hi, 
                 pos_lo, 
                 thread_id, 
                 @@IDENTITY 
          INTO   frame_note 
          FROM   frame 
          WHERE  pos_hi = @pos_hi 
                 AND pos_lo = @pos_lo 

          COMMIT TRAN 
      END 
    ELSE 
      BEGIN 
          BEGIN TRAN 

          INSERT INTO note 
          VALUES      (@text) 

          INSERT INTO frame_note 
          VALUES      (@pos_hi, 
                       @pos_lo, 
                       @thread_id, 
                       @@IDENTITY) 

          COMMIT TRAN 
      END 

    RETURN 0 