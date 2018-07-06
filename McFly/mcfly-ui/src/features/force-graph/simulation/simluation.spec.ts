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
                const a = Math.atan(1);
                const i = 1.0 / 32 * Math.abs(Math.cos(a)) || 0;
                const j = 1.0 / 32 * Math.abs(Math.sin(a)) || 0;
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
                const a = Math.atan(1);
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
                    1 + f,
                    -1,
                    -4 - f,
                    -1
                ]));
            }
        });

        it("should calculate forces for 3 nodes", () => {
            const masses = new Float32Array([5, 10, 1]);
            const positions = new Float32Array([
                2,
                3,
                5,
                8,
                5,
                2
            ]);
            const links = new Float32Array(0);
            const simulation = new SimulationEngine(masses, positions, links, 2);
            simulation.tick();
            const result = simulation.getPositions();
            expect(result.length).toBe(6);
            const expected = new Float32Array([
                0.7690470218658447,
                1.8970948457717896,
                5.756611347198486,
                9.538796424865723,
                5.474341869354248,
                1.5641083717346191
            ]);
            expect(result).toEqual(expected);
        });
    });

    describe("links", () => {
        it("should force 2 nodes together", () => {
            const masses = new Float32Array([1, 1]);
            const positions = new Float32Array([1, 5, 5, 1]);
            const links = new Float32Array([0, 1, .5]);
            const simulation = new SimulationEngine(masses, positions, links, 2);
            simulation.tick();
            const result = simulation.getPositions();
            const a = Math.atan(1);
            const i = 1.0 / 32 * Math.abs(Math.cos(a)) || 0;
            const j = 1.0 / 32 * Math.abs(Math.sin(a)) || 0;
            expect(result).toEqual(new Float32Array([
                1 - i * .5,
                5 + j * .5,
                5 + i * .5,
                1 - j * .5
            ]));
        });

        it("should work together if there are multiple", () => {
            const masses = new Float32Array([1, 1, 1]);
            const positions = new Float32Array([
                1,
                5,
                5,
                1,
                2,
                2
            ]);
            const links = new Float32Array([
                0,
                1,
                .5,
                0,
                2,
                .3
            ]);
            const simulation = new SimulationEngine(masses, positions, links, 2);
            simulation.tick();
            const result = simulation.getPositions();
            const ax = 1;
            const ay = 5;

            const bx = 5;
            const by = 1;
            const cx = 2;
            const cy = 2;
            const dxab = ax - bx;
            const dxac = ax - cx;
            const dyab = ay - by;
            const dyac = ay - cy;
            const dxbc = bx - cx;
            const dybc = by - cy;
            const alphaab = Math.atan(dyab * 1.0 / dxab);
            const alphaac = Math.atan(dyac * 1.0 / dxac);
            const alphabc = Math.atan(dybc * 1.0 / dxbc);
            const ab2 = dxab ** 2 + dyab ** 2;
            const ac2 = dxac ** 2 + dyac ** 2;
            const bc2 = dxbc ** 2 + dybc ** 2;
            const fab = 1.0 / ab2 * .5;
            const fac = 1.0 / ac2 * .3;
            const fbc = 1.0 / bc2;
            const fabi = fab * Math.abs(Math.cos(alphaab));
            const fabj = fab * Math.abs(Math.sin(alphaab));
            const faci = fac * Math.abs(Math.cos(alphaac));
            const facj = fac * Math.abs(Math.sin(alphaac));
            const fbci = fbc * Math.abs(Math.cos(alphabc));
            const fbcj = fbc * Math.abs(Math.sin(alphabc));
            const expected = new Float32Array([
                (ax - fabi - faci),
                (ay + fabj + facj),
                (bx + fabi + fbci),
                (by - fabj - fbcj),
                (cx + faci - fbci),
                (cy - facj + fbcj)
            ]);

            expect(result.length).toBe(expected.length);
            for (let i = 0; i < expected.length; i++) {
                expect(result[i]).toBeCloseTo(expected[i], 5);
            }
        });
    });
});

describe("3D", () => {
    describe("nodes only", () => {
        it("should force 2 nodes apart", () => {
            {
                const masses = new Float32Array([1, 1]);
                const positions = new Float32Array([
                    1,
                    1,
                    1,
                    5,
                    5,
                    5
                ]);
                const links = new Float32Array(0);
                const simulation = new SimulationEngine(masses, positions, links, 3);
                simulation.tick();
                const results = simulation.getPositions();
                const x1 = positions[0];
                const y1 = positions[1];
                const z1 = positions[2];
                const x2 = positions[3];
                const y2 = positions[4];
                const z2 = positions[5];
                const dx = x1 - x2;
                const dy = y1 - y2;
                const dz = z1 - z2;
                const fi = Math.abs(Math.atan2(Math.sqrt(dy ** 2 + dz ** 2), dx));
                const fj = Math.abs(Math.atan2(Math.sqrt(dx ** 2 + dz ** 2), dy));
                const fh = Math.abs(Math.atan2(Math.sqrt(dx ** 2 + dy ** 2), dz));

                const expected = new Float32Array([
                    (x1 + (fi * Math.sign(dx))),
                    (y1 + (fj * Math.sign(dy))),
                    (z1 + (fh * Math.sign(dz))),
                    (x2 + (fi * -Math.sign(dx))),
                    (y2 + (fj * -Math.sign(dy))),
                    (z2 + (fh * -Math.sign(dz)))
                ]);
                expect(results).toEqual(expected);
            }
            {
                const masses = new Float32Array([1, 1]);
                const positions = new Float32Array([
                    1,
                    3,
                    2,
                    7,
                    8,
                    1
                ]);
                const links = new Float32Array(0);
                const simulation = new SimulationEngine(masses, positions, links, 3);
                simulation.tick();
                const results = simulation.getPositions();
                const x1 = positions[0];
                const y1 = positions[1];
                const z1 = positions[2];
                const x2 = positions[3];
                const y2 = positions[4];
                const z2 = positions[5];
                const dx = x1 - x2;
                const dy = y1 - y2;
                const dz = z1 - z2;
                const fi = Math.abs(Math.atan2(Math.sqrt(dy ** 2 + dz ** 2), dx));
                const fj = Math.abs(Math.atan2(Math.sqrt(dx ** 2 + dz ** 2), dy));
                const fh = Math.abs(Math.atan2(Math.sqrt(dx ** 2 + dy ** 2), dz));

                const expected = new Float32Array([
                    (x1 + (fi * Math.sign(dx))),
                    (y1 + (fj * Math.sign(dy))),
                    (z1 + (fh * Math.sign(dz))),
                    (x2 + (fi * -Math.sign(dx))),
                    (y2 + (fj * -Math.sign(dy))),
                    (z2 + (fh * -Math.sign(dz)))
                ]);
                expect(results).toEqual(expected);
            }
        });
    });

    describe("links", () => {
        it("should force 2 nodes together", () => {
            {
                const masses = new Float32Array([1, 1]);
                const positions = new Float32Array([
                    1,
                    1,
                    1,
                    5,
                    5,
                    5
                ]);
                const links = new Float32Array([0,1,.5]);
                const simulation = new SimulationEngine(masses, positions, links, 3);
                simulation.tick();
                const results = simulation.getPositions();
                const x1 = positions[0];
                const y1 = positions[1];
                const z1 = positions[2];
                const x2 = positions[3];
                const y2 = positions[4];
                const z2 = positions[5];
                const dx = x1 - x2;
                const dy = y1 - y2;
                const dz = z1 - z2;
                const fi = Math.abs(Math.atan2(Math.sqrt(dy ** 2 + dz ** 2), dx));
                const fj = Math.abs(Math.atan2(Math.sqrt(dx ** 2 + dz ** 2), dy));
                const fh = Math.abs(Math.atan2(Math.sqrt(dx ** 2 + dy ** 2), dz));

                const expected = new Float32Array([
                    (x1 + (fi * .5 * Math.sign(dx))),
                    (y1 + (fj * .5 * Math.sign(dy))),
                    (z1 + (fh * .5 * Math.sign(dz))),
                    (x2 + (fi * .5 * -Math.sign(dx))),
                    (y2 + (fj * .5 * -Math.sign(dy))),
                    (z2 + (fh * .5 * -Math.sign(dz)))
                ]);
                expect(results).toEqual(expected);
            }
        });
    });
});