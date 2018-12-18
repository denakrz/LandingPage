context('Actions', () => {
    beforeEach(() => {
      cy.visit('http://localhost:49495/index.html')
    })

//clases .
//id #
//name la palabra

    it('.clickLogo()', () => {
        cy.get('.logo > a > img').click()
        cy.get('.logo > a ')
        .should('have.attr', 'href')    
        cy.get('.logo > a > img')
        .should('have.attr', 'src') 
    })    
    
    it('.existLogin()', () => {
        cy.get('#myBtn').click()
        cy.get('.close').click()
    })  
    
    it('.goToPage()', () => {
        cy.get('.a > :nth-child(2) > #img91').click()
        cy.get('.a > a')
        .should('have.attr', 'href')
        cy.get('.b > :nth-child(2) > #img91').click()
        cy.get('.b > a')
        .should('have.attr', 'href')
        cy.get('[href="#ins"] > #img91').click()
        cy.get('#open').contains("Tu primer experiencia")
    })  

    it ('.clickButton()',() => {
        cy.get('#in').click()
        cy.go('back')
    })

})