CREATE TABLE [dbo].[trace_info]
(
    [lock] CHAR(1) NOT NULL PRIMARY KEY DEFAULT 'X', 
    [start_pos_hi] INT NOT NULL, 
    [start_pos_lo] INT NOT NULL, 
    [end_pos_hi] INT NOT NULL, 
    [end_pos_lo] INT NOT NULL, 
    CONSTRAINT [CK_trace_info_lock] CHECK (lock = 'X'), 
    CONSTRAINT [CK_trace_info_positions_sign] CHECK (start_pos_hi >= 0 AND start_pos_lo >= 0 AND end_pos_hi >= 0 AND end_pos_lo >= 0),
    CONSTRAINT [CK_trace_info_start_before_end] CHECK (start_pos_hi < end_pos_hi OR (start_pos_hi = end_pos_hi AND start_pos_lo < end_pos_lo))
)
