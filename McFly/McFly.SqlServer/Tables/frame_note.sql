CREATE TABLE [dbo].[frame_note] (
	[pos_hi] INT NOT NULL,
	[pos_lo] INT NOT NULL,
	[thread_id] INT NOT NULL,
	[note_id] INT NOT NULL,
	CONSTRAINT pk_frame_note PRIMARY KEY (
		pos_hi,
		pos_lo,
		thread_id,
		note_id
		),
	CONSTRAINT fk_frame_note_frame FOREIGN KEY (
		[pos_hi],
		[pos_lo],
		[thread_id]
		) REFERENCES frame(pos_hi, pos_lo, thread_id),
	CONSTRAINT fk_frame_note_note FOREIGN KEY ([note_id]) REFERENCES note(id)
	)
