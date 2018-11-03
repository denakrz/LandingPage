Esta el der (en visio y pdf) y los scripts de la db.


Hay 3 campos unique:

IdPostulant en Studies

Username en Login

IdProgressInstance-IdPostulant de Instance



En TypeAttached, la idea es que se incluya:
Form, DNI, CUIL, Certificate, Resume, GitHub, LinkedIn
(y todo lo que haya que adjuntar) 

State, deberia incluir Accepted, Rejected, Pending y Revision
(hasta ahora no se me ocurre otro estado posible)


En ProgressInstance:
Group Interview, IndivInterview-Technical, IndivInterview-Psycho, HelthExam


Y LoginType, solo hay dos: Postulant y RRHH
