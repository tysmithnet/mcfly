import {SimulationEngine} from ".";

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
            const masses = new Float32Array([1]);
            const positions = new Float32Array([1]);
            const links = new Float32Array(0);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array([1]));
        });

        it("should act on a pair of nodes", () => {
            const masses = new Float32Array([1, 1]);
            const positions = new Float32Array([1, 5]);
            const links = new Float32Array(0);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array([
                (1 - 1.0 / 16),
                (5 + 1.0 / 16)
            ]));
        });

        it("should calculate forces for 3 nodes", () => {
            const masses = new Float32Array([1, 3, 2]);
            const positions = new Float32Array([1, 5, 6]);
            const links = new Float32Array(0);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array([
                (1 - 3.0 / 16 - 2.0 / 25),
                (5 + 3.0 / 16 - 6),
                (6 + 2.0 / 25 + 6)
            ]));
        });

        it("should calculate forces for 4 nodes", () => {
            const masses = new Float32Array([1, 1, 1, 1]);
            const positions = new Float32Array([0, 1, 3, 4]);
            const links = new Float32Array(0);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array([
                (0 - 1 - 1.0 / 9 - 1.0 / 16),
                (1 + 1 - 1.0 / 4 - 1.0 / 9),
                (3 + 1.0 / 9 + 1.0 / 4 - 1),
                (4 + 1.0 / 16 + 1.0 / 9 + 1)
            ]));
        });
    });

    describe("links", () => {
        it("should force 2 nodes together", () => {
            const masses = new Float32Array([1, 1]);
            const positions = new Float32Array([1, 5]);
            const links = new Float32Array([0, 1, .5]);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array([
                (1 - 1.0 * .5 / 16),
                (5 + 1.0 * .5 / 16)
            ]));
        });

        it("should work together if there are multiple", () => {
            const masses = new Float32Array([1, 3, 2]);
            const positions = new Float32Array([1, 5, 6]);
            const links = new Float32Array([
                0,
                1,
                .5,
                0,
                2,
                .3
            ]);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array([
                (1 - 3.0 * .5 / 16 - 2.0 * .3 / 25),
                (5 + 3.0 * .5 / 16 - 6),
                (6 + 2.0 * .3 / 25 + 6)
            ]));
        });
    });
});

describe("2D", () => {
    describe("nodes only", () => {
        it("should not move a solitary node", () => {
            const masses = new Float32Array([1]);
            const positions = new Float32Array([1, 1]);
            const links = new Float32Array(0);
            const simulation = new SimulationEngine(masses, positions, links, 2);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array([1, 1]));
        });

        it("should act on a pair of nodes", () => {
            {
                const masses = new Float32Array([1, 1]);
                const positions = new Float32Array([1, 1, 5, 5]);
                const links = new Float32Array(0);
                const simulation = new SimulationEngine(masses, positions, links, 2);
                simulation.tick();
                const result = simulation.getPositions();
                const a = Math.atan(1);
                const i = 1.0 / 32 * Math.cos(a);
                const j = 1.0 / 32 * Math.sin(a);
                expect(result).toEqual(new Float32Array([
                    1 - i,
                    1 - j,
                    5 + i,
                    5 + j
                ]));
            }
            {
                const masses = new Float32Array([1, 1]);
                const positions = new Float32Array([5, 5, 1, 1]);
                const links = new Float32Array(0);
                const simulation = new SimulationEngine(masses, positions, links, 2);
                simulation.tick();
                const result = simulation.getPositions();
                const a = Math.atan(1);
                const i = 1.0 / 32 * Math.cos(a);
                const j = 1.0 / 32 * Math.sin(a);
                expect(result).toEqual(new Float32Array([
                    5 + i,
                    5 + j,
                    1 - i,
                    1 - j
                ]));
            }
            {
                const masses = new Float32Array([1, 1]);
                const positions = new Float32Array([1, 5, 5, 1]);
                const links = new Float32Array(0);
                const simulation = new SimulationEngine(masses, positions, links, 2);
                simulation.tick();
                const result = simulation.getPositions();
                const a = Math.atan(-1);
                const i = 1.0 / 32 * Math.cos(a);
                const j = 1.0 / 32 * Math.sin(a);
                expect(result).toEqual(new Float32Array([
                    1 - i,
                    5 + j,
                    5 + i,
                    1 - j
                ]));
            }
            {
                const masses = new Float32Array([1, 1]);
                const positions = new Float32Array([5, 1, 1, 5]);
                const links = new Float32Array(0);
                const simulation = new SimulationEngine(masses, positions, links, 2);
                simulation.tick();
                const result = simulation.getPositions();
                const a = Math.atan(-1);
                const i = 1.0 / 32 * Math.cos(a);
                const j = 1.0 / 32 * Math.sin(a);
                expect(result).toEqual(new Float32Array([
                    5 + i,
                    1 - j,
                    1 - i,
                    5 + j
                ]));
            }
        });

        it("should work for nodes with x1 == x2 or y1 == y2", () => {
            {
                const masses = new Float32Array([5, 3]);
                const positions = new Float32Array([-1, 1, -1, -4]);
                const links = new Float32Array(0);
                const simulation = new SimulationEngine(masses, positions, links, 2);
                simulation.tick();
                const result = simulation.getPositions();
                const f = 15.0 / 25;
                expect(result).toEqual(new Float32Array([
                    -1, 1 + f,
                    -1,
                    -4 - f
                ]));
            }
            {
                const masses = new Float32Array([5, 3]);
                const positions = new Float32Array([1, -1, -4, -1]);
                const links = new Float32Array(0);
                const simulation = new SimulationEngine(masses, positions, links, 2);
                simulation.tick();
                const result = simulation.getPositions();
                const f = 15.0 / 25;
                expect(result).toEqual(new Float32Array([
                    1 + f, -1,
                    -4 - f,
                    -1
                ]));
            }
        });

        it("should calculate forces for 4 nodes", () => {
            ;
        });
    });

    describe("links", () => {
        it("should force 2 nodes together", () => {
            const masses = new Float32Array([1, 1]);
            const positions = new Float32Array([1, 5]);
            const links = new Float32Array([0, 1, .5]);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array([
                (1 - 1.0 * .5 / 16),
                (5 + 1.0 * .5 / 16)
            ]));
        });

        it("should work together if there are multiple", () => {
            const masses = new Float32Array([1, 3, 2]);
            const positions = new Float32Array([1, 5, 6]);
            const links = new Float32Array([
                0,
                1,
                .5,
                0,
                2,
                .3
            ]);
            const simulation = new SimulationEngine(masses, positions, links, 1);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result).toEqual(new Float32Array([
                (1 - 3.0 * .5 / 16 - 2.0 * .3 / 25),
                (5 + 3.0 * .5 / 16 - 6),
                (6 + 2.0 * .3 / 25 + 6)
            ]));
        });
    });
});

// 2d note: alphaXY = Math.atan(dy/dx); i = forceMag * Math.cos(alphaXY) j =
// forceMag * Math.sin(alphaXY)