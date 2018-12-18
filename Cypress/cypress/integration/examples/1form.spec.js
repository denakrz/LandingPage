context('Actions', () => {
    beforeEach(() => {
      cy.visit('http://localhost:49495/form.html')
    })
    
//clases .
//id #
//name la palabra

    it('.typeForm()', () => {
    
        cy.get('#name', { delay: 200 })
        .type('Ejemplo').should('have.value', 'Ejemplo')

        cy.wait(300)
        cy.get('#lastname', { delay: 200 })
        .type('Ejemplo').should('have.value', 'Ejemplo')

        cy.wait(300)
        cy.get('#birth', { delay: 200 })
        .type('1998-12-30').should('have.value', '1998-12-30')

        cy.wait(300)
        cy.get('#dni', { delay: 200 })
        .type('12598515').should('have.value', '12598515')

        cy.wait(300)
        cy.get('#email', { delay: 200 })
        .type('persona@example.com').should('have.value', 'persona@example.com')
        
        cy.wait(300)
        cy.get('#phoneHome', { delay: 200 })
        .type('123456').should('have.value', '123456')

        cy.wait(300)
        cy.get('#phoneMobile', { delay: 200 })
        .type('123456').should('have.value', '123456')
        
        cy.wait(300)
        cy.get('#github', { delay: 200 })
        .type('ejemplu').should('have.value', 'ejemplu')
        
        cy.wait(300)
        cy.get('#linkedin', { delay: 200 })
        .type('ejem').should('have.value', 'ejem')

        //STUDY
        cy.wait(300)
        cy.get('#universitary').check()

        cy.wait(300)
        cy.get('#institution', { delay: 200 })
        .type('Universidad de Buenos Aires').should('have.value', 'Universidad de Buenos Aires')

        cy.wait(300)
        cy.get('#career', { delay: 200 })
        .type('Ing Informatica').should('have.value', 'Ing Informatica')

        //Study1
        cy.wait(300)
        cy.get('#ongoing').check()

        //ENGLISH
        cy.wait(300)
        cy.get('#engYes').check()

        //COMBOS
        cy.wait(300)
        cy.get('#speakEnglish').select('Intermedio')
        cy.wait(300)
        cy.get('#writtenEnglish').select('Intermedio')
        cy.wait(300)
        cy.get('#listenEnglish').select('Intermedio')

        cy.wait(300)
        cy.get('#technologies', { delay: 200 })
        .type('Todas').should('have.value', 'Todas')

        cy.wait(300)
        cy.get('#infoProg').select('Facultad')
        
        cy.wait(300)
        cy.get('#intProg', { delay: 200 })
        .type('Si').should('have.value', 'Si')

        //CONVER THEME
        cy.wait(300)
        cy.get('#converYes').check()

        //COD
        cy.wait(300)
        cy.get('#codYes').check()

        cy.wait(300)
        cy.get('#tools', { delay: 200 })
        .type('Varias').should('have.value', 'Varias')

        //PC
        cy.wait(300)
        cy.get('#pcYes').check()

        cy.wait(300)
        cy.get('#experience', { delay: 200 })
        .type('Bastante').should('have.value', 'Bastante')

        cy.get('#button').click()
        cy.wait(3000)
        cy.get('.swal-button').click()
    
    })

})