# Collection of Ideas
The good, bad, and ugly

### Node types
- Position
- Frame
    - Register set
- Stack frame
- Address
- Module
- Function
- Memory Chunk
    - if we enforce 

### Relationship types
- at ??
    - position
- has ?? 
    - stack frame (frame N:N stack frame)
    - mem (pos N:N memory chunk)
- references address
    - stack pointer
    - return address
    - base pointer


### Link examples
- Frame -[:at]-> Position
- Frame -[:references{type: ""}]-> Address
- Frame -[:has]-> Stack Frame
- Stack Frame -[:references{type: "stack_pointer"}]-> Address
- Stack Frame -[:references{type: "return_address"}]-> Address


### Relationships
