/// <reference types="Cypress" />

context("Actions", () => {
  beforeEach(() => {
    cy.visit("http://localhost:8080/");
  });

  it("should render hi!", () => {
    cy.get("#root").then(a => {
      expect(a).to.be.ok;
    });
  });
});
