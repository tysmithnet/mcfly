import { SimulationEngine } from ".";

it("should handle an empty array", () => {
    const masses = new Float32Array(0);
    const positions = new Float32Array(0);
    const links = new Float32Array(0);

    const simulation = new SimulationEngine(masses, positions, links, 1);
    simulation.tick();
    const result = simulation.getPositions();
    expect(result).toEqual(new Float32Array(0));
});
  
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