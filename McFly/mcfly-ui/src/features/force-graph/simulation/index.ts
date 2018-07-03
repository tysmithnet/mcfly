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
    tick() : void;
    getPositions() : Float32Array;
}

export class SimulationEngine implements Simulation
{
    private masses : Float32Array;
    private positions : Float32Array;
    private links : Float32Array;
    private n : number;
    private numDimensions : number;

    constructor(masses : Float32Array, positions : Float32Array, links : Float32Array, numDimensions : number) {
        if (masses == null || positions == null || links == null || numDimensions == null) {
            throw new Error("All parameters are required")
        }
        if (numDimensions !== 1 && numDimensions !== 2 && numDimensions !== 3) {
            throw new Error("numDimensions must be 1,2, or 3");
        }
        if (masses.length !== positions.length * numDimensions) {
            throw new Error("The number of elements in positions should be numDimensions * masses.length");
        }
        this.masses = masses;
        this.positions = positions;
        this.links = links;
        this.n = masses.length;
        this.numDimensions = numDimensions;
    }

    public tick() : void {
        for(let i = 0; i < this.n; i++) {
            for(let j = i + 1; j < this.n; j++) {
                this.applyForces(i, j);
            }
        }
    }

    public getPositions() : Float32Array {
        return Float32Array.from(this.positions);
    }

    private applyForces(first : number, second : number): void {
        const m1 = this.masses[first];
        const m2 = this.masses[second];
        switch (this.numDimensions) {
            case 3:
                {
                    const x1 = this.positions[first * 3];
                    const y1 = this.positions[(first * 3) + 1];
                    const z1 = this.positions[(first * 3) + 2];
                    const x2 = this.positions[second * 3];
                    const y2 = this.positions[(second * 3) + 1];
                    const z2 = this.positions[(second * 3) + 2];              
                    const dx = x1 - x2;
                    const dy = y1 - y2;
                    const dz = z1 - z2;
                    const forceMagnitude = (m1 * m2) / (dx ** 2 + dy ** 2 + dz ** 2);
                    // todo: finish
                }
            case 2:
                {
                    const x1 = this.positions[first * 2];
                    const y1 = this.positions[(first * 2) + 1];
                    const x2 = this.positions[second * 2];
                    const y2 = this.positions[(second * 2) + 1];
                    const dx = x1 - x2;
                    const dy = y1 - y2;
                    const forceMagnitude =  (m1 * m2) / (dx ** 2 + dy ** 2);
                    const alphaXY = Math.atan(dy /dx);
                    const i = forceMagnitude * Math.cos(alphaXY);
                    const j = forceMagnitude * Math.sin(alphaXY);
                    this.positions[first * 2] += i;
                    this.positions[(first * 2) + 1] += j;
                    this.positions[second * 2] -= i;
                    this.positions[(second * 2) + 1] -= j;
                }
            case 1:
                {
                    const x1 = this.positions[first];
                    const x2 = this.positions[second];
                    if(x1 === x2) {
                        return;
                    }
                    const dx = x1 - x2;
                    const forceMagnitude = (m1 * m2 * 1.0) / (dx ** 2);
                    this.positions[first] -= forceMagnitude;
                    this.positions[second] += forceMagnitude;
                }
        }
    }
}
