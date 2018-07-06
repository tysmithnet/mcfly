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
    private nodeLinkMap : Map < number,
    Set < number >> = new Map < number,
    Set < number >> ();
    constructor(masses : Float32Array, positions : Float32Array, links : Float32Array, numDimensions : number) {
        if (masses == null || positions == null || links == null || numDimensions == null) {
            throw new Error("All parameters are required")
        }
        if (numDimensions !== 1 && numDimensions !== 2 && numDimensions !== 3) {
            throw new Error("numDimensions must be 1,2, or 3");
        }
        if (masses.length !== positions.length / numDimensions) {
            throw new Error("The number of elements in positions should be numDimensions * masses.length");
        }
        this.masses = masses;
        this.positions = positions;
        this.links = links;
        this.n = masses.length;
        this.numDimensions = numDimensions;

        for (let i = 0; i < links.length; i += 3) {
            const source = links[i];
            const target = links[i + 1];
            const sourceArr = this
                .nodeLinkMap
                .get(source);
            const targetArr = this
                .nodeLinkMap
                .get(target);
            if (sourceArr) {
                sourceArr.add(i);
            } else {
                this
                    .nodeLinkMap
                    .set(source, new Set < number > ([i]));
            }
            if (targetArr) {
                targetArr.add(i);
            } else {
                this
                    .nodeLinkMap
                    .set(target, new Set < number > ([i]));
            }
        }
    }

    public tick() : void {
        const buffer = new Float32Array(this.positions);
        for (let i = 0; i < this.n; i++) {
            for (let j = i + 1; j < this.n; j++) {
                this.applyForces(i, j, buffer);
            }
        }
        this.positions = buffer;
    }

    public getPositions() : Float32Array {
        return Float32Array.from(this.positions);
    }

    private applyForces(first : number, second : number, buffer : Float32Array) : void {
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
                const sourceLinks = this
                    .nodeLinkMap
                    .get(first);
                const targetLinks = this
                    .nodeLinkMap
                    .get(second);
                
                let fi = Math.abs(Math.atan2(Math.sqrt(dy ** 2 + dz ** 2), dx)) || 0;
                let fj = Math.abs(Math.atan2(Math.sqrt(dx ** 2 + dz ** 2), dy)) || 0;
                let fh = Math.abs(Math.atan2(Math.sqrt(dx ** 2 + dy ** 2), dz)) || 0;
                
                if (sourceLinks && targetLinks) {
                    const commonLinks = new Set([...sourceLinks].filter(x => targetLinks.has(x)));
                    for (const linkIndex of commonLinks) {
                        const linkForce = this.links[linkIndex + 2];
                        fi *= linkForce; // todo: do we think we will have additional strategies for link calculation
                        fj *= linkForce;
                        fh *= linkForce;
                    }
                }

                if (x1 < x2) {
                    buffer[first * 3] -= fi;
                    buffer[second * 3] += fi;
                } else {
                    buffer[first * 3] += fi;
                    buffer[second * 3] -= fi;
                }

                if (y1 < y2) {
                    buffer[(first * 3) + 1] -= fj;
                    buffer[(second * 3) + 1] += fj;
                } else {
                    buffer[(first * 3) + 1] += fj;
                    buffer[(second * 3) + 1] -= fj;
                }

                if (z1 < z2) {
                    buffer[(first * 3) + 2] -= fh;
                    buffer[(second * 3) + 2] += fh;
                } else {
                    buffer[(first * 3) + 2] += fh;
                    buffer[(second * 3) + 2] -= fh;
                }
            }
                break;
            case 2:
                {
                    const x1 = this.positions[first * 2];
                    const y1 = this.positions[(first * 2) + 1];
                    const x2 = this.positions[second * 2];
                    const y2 = this.positions[(second * 2) + 1];
                    const dx = x1 - x2;
                    const dy = y1 - y2;
                    let forceMagnitude = (m1 * m2) / (dx ** 2 + dy ** 2);
                    const sourceLinks = this
                        .nodeLinkMap
                        .get(first);
                    const targetLinks = this
                        .nodeLinkMap
                        .get(second);
                    if (sourceLinks && targetLinks) {
                        const commonLinks = new Set([...sourceLinks].filter(x => targetLinks.has(x)));
                        for (const linkIndex of commonLinks) {
                            const linkForce = this.links[linkIndex + 2];
                            forceMagnitude *= linkForce; // todo: do we think we will have additional strategies for link calculation
                        }
                    }
                    const alphaXY = Math.atan(dy / dx);
                    const i = forceMagnitude * Math.abs(Math.cos(alphaXY)) || 0;
                    const j = forceMagnitude * Math.abs(Math.sin(alphaXY)) || 0;

                    if (x1 < x2) {
                        buffer[first * 2] -= i;
                        buffer[second * 2] += i;
                    } else {
                        buffer[first * 2] += i;
                        buffer[second * 2] -= i;
                    }

                    if (y1 < y2) {
                        buffer[(first * 2) + 1] -= j;
                        buffer[(second * 2) + 1] += j;
                    } else {
                        buffer[(first * 2) + 1] += j;
                        buffer[(second * 2) + 1] -= j;
                    }
                }
                break;
            case 1:
                {
                    const x1 = this.positions[first];
                    const x2 = this.positions[second];
                    if (x1 === x2) {
                        return;
                    }
                    const dx = x1 - x2;
                    let forceMagnitude = (m1 * m2 * 1.0) / (dx ** 2);
                    const sourceLinks = this
                        .nodeLinkMap
                        .get(first);
                    const targetLinks = this
                        .nodeLinkMap
                        .get(second);
                    if (sourceLinks && targetLinks) {
                        const commonLinks = new Set([...sourceLinks].filter(x => targetLinks.has(x)));
                        for (const linkIndex of commonLinks) {
                            const linkForce = this.links[linkIndex + 2];
                            forceMagnitude *= linkForce; // todo: do we think we will have additional strategies for link calculation
                        }
                    }

                    buffer[first] -= forceMagnitude;
                    buffer[second] += forceMagnitude;
                }
        }
    }
}
