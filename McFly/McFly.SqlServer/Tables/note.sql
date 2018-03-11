CREATE TABLE [dbo].[note]
(
    [id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [pos_hi] INT NOT NULL,
    [pos_lo] INT NOT NULL,
    [thread_id] INT NOT NULL,
    [create_dt] DATETIME NOT NULL, 
    [content] TEXT NOT NULL,

    CONSTRAINT FK_note_frame FOREIGN KEY (pos_hi, pos_lo, thread_id) REFERENCES frame (pos_hi, pos_lo, thread_id)
)

GO
