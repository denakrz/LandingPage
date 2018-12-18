context('Actions', () => {
    beforeEach(() => {
      cy.visit('http://localhost:49495/index.html')
    })

    it('.Login()', () => {
        cy.get('#myBtn').click()
        cy.get('#user')
        .type('UserPostulant').should('have.value', 'UserPostulant')
        cy.get('#psw')
        .type('Userpostulant10!').should('have.value', 'Userpostulant10!')

        cy.get('.logo > a ')
        .should('have.attr', 'href')
        cy.get('#but1').click()
        
        cy.wait(4000)
        cy.location().should((location) => {
            expect(location.pathname).to.eq('/postulant_view.html')
        })
        cy.get('#user_name').contains("Welcome")
    })
})