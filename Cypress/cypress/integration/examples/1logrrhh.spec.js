context('Actions', () => {
    beforeEach(() => {
      cy.visit('http://localhost:49495/index.html')
    })

    it('.Login()', () => {
        cy.get('#myBtn').click()
        cy.get('#user')
        .type('UserRRHH').should('have.value', 'UserRRHH')
        cy.get('#psw')
        .type('Userrrhh10!').should('have.value', 'Userrrhh10!')

        cy.get('.logo > a ')
        .should('have.attr', 'href') 
        cy.get('#but1').click()
        
        cy.location().should((location) => {
            expect(location.pathname).to.eq('/list_post.html')
        })

        cy.get('#list_post > h3').contains("Lista de postulantes")    
    }) 
})