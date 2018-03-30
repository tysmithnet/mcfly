CREATE TABLE [dbo].[stackframe] (
	[pos_hi] INT NOT NULL,
	[pos_lo] INT NOT NULL,
	[thread_id] INT NOT NULL,
	[depth] INT NOT NULL,
	[stack_pointer] BIGINT NULL,
	[return_address] BIGINT NULL,
	[module] VARCHAR(256) NULL,
	[function_name] VARCHAR(512) NULL,
	[offset] BIGINT NULL,
	CONSTRAINT PK_stackframe PRIMARY KEY (
		pos_hi,
		pos_lo,
		thread_id,
		depth
		)
	)
