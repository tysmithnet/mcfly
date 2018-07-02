// Well Separated Pair Decomposition Force Directed Graph Implementation
// http://www.mdpi.com/1999-4893/9/3/53

/*
                THE SIMULATION KNOWS NOTHING OF THE DOMAIN
                IT DEALS WITH RAW ARRAYS TO FORCE THE CLIENT
                TO PROVIDE DATA OPTIMIZED FOR GPU USAGE
*/

/**
 * @description Represents an object that is capable of simulating the forces between
 * nodes in 1, 2, or 3 dimensions.
 */
export interface Simulation
{
    tick():void;
    getPositions():Float32Array;
}

export class SimulationEngine implements Simulation
{
    private masses:Float32Array;
    private positions:Float32Array;
    private links:Float32Array;
    private n:number;
    private numDimensions:number;

    constructor(masses:Float32Array, positions:Float32Array, links:Float32Array, numDimensions:number) {
        if(masses == null || positions == null || links == null || numDimensions == null){
            throw new Error("All parameters are required")
        }
        if(numDimensions !== 1 && numDimensions !== 2 && numDimensions !== 3) {
            throw new Error("numDimensions must be 1,2, or 3");
        }
        if(masses.length !== positions.length * numDimensions) {
            throw new Error("The number of elements in positions should be numDimensions * masses.length");
        }
        this.masses = masses;
        this.positions = positions;
        this.links = links;
        this.n = masses.length;
        this.numDimensions = numDimensions;
    }

    public tick():void {
        ;
    }

    public getPositions():Float32Array{
        return new Float32Array(0);
    }
}

