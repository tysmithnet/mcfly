import { SimulationEngine } from ".";

describe("trivial", () => {
    it("should handle empty arrays", () => {
        const masses = new Float32Array(0);
        const positions = new Float32Array(0);
        const links = new Float32Array(0);
    
        const simulation = new SimulationEngine(masses, positions, links, 1);
        simulation.tick();
        const result = simulation.getPositions();
        expect(result).toEqual(new Float32Array(0));
    });
});

describe("error handling", () => {
    it("should reject poorly sized arrays", () => {
        const masses = new Float32Array(0);
        const positions = new Float32Array(1);
        const links = new Float32Array(0);
        const throws = () => new SimulationEngine(masses, positions, links, 1);
        expect(throws).toThrow();
    });
    
    it("should reject numDimensions not in (1,2,3)", () => {
        const masses = new Float32Array(0);
        const positions = new Float32Array(0);
        const links = new Float32Array(0);
        const throws0 = () => new SimulationEngine(masses, positions, links, 0);
        const throws1 = () => new SimulationEngine(masses, positions, links, 1.2);
        const throws2 = () => new SimulationEngine(masses, positions, links, -1);
        const throws3 = () => new SimulationEngine(masses, positions, links, 4);
        expect(throws0).toThrow();
        expect(throws1).toThrow();
        expect(throws2).toThrow();
        expect(throws3).toThrow();
    });
});

describe("1D", () => {
    describe("nodes only", () => {
        it("should not move a solitary node", () => {
            const masses = new Float32Array([1,1]);
            const positions = new Float32Array([1,5]);
            const links = new Float32Array(0);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array( [(1 - 1.0/16), (5 + 1.0/16)]));
        });
        
        it("should act on a pair of nodes", () => {
            const masses = new Float32Array([1,1]);
            const positions = new Float32Array([1,5]);
            const links = new Float32Array(0);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array( [0.9375, 5.0625]));
        });
    
        it("should calculate forces for 3 nodes", () => {
            const masses = new Float32Array([1,3,2]);
            const positions = new Float32Array([1,5,6]);
            const links = new Float32Array(0);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array([(1 - 3.0/16 - 2.0/25), (5 + 3.0/16 - 6), (6 + 2.0/25 + 6)]));
        });
    
        it("should calculate forces for 4 nodes", () => {
            const masses = new Float32Array([1,1,1,1]);
            const positions = new Float32Array([0,1,3,4]);
            const links = new Float32Array(0);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array([(0 - 1 - 1.0/9 - 1.0/16), (1 + 1 - 1.0/4 - 1.0/9), (3 + 1.0/9 + 1.0/4 - 1), (4 + 1.0/16 + 1.0/9 + 1), ]));
        });
    });

    describe("links", () => {
        it("should force 2 nodes together", () => {
            const masses = new Float32Array([1,1]);
            const positions = new Float32Array([1,5]);
            const links = new Float32Array([0,1,.5]);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array( [(1 - 1.0*.5/16), (5 + 1.0*.5/16)]));
        });

        it("should work together if there are multiple", () => {
            const masses = new Float32Array([1,3,2]);
            const positions = new Float32Array([1,5,6]);
            const links = new Float32Array([0,1,.5,0,2,.3]);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array([(1 - 3.0 *.5/16 - 2.0*.3/25), (5 + 3.0*.5/16 - 6), (6 + 2.0*.3/25 + 6)]));
        });
    });
});

// 2d note:
// alphaXY = Math.atan(dy/dx);
// i = forceMag * Math.cos(alphaXY)
// j = forceMag * Math.sin(alphaXY)