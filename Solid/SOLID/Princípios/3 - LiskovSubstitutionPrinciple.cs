using System;

namespace SOLID.Princípios
{
    // Nesse pequeno exemplo, temos uma aplicação do LSB: O código continua funcionando, independente de passarmos o tipo A ou B
    // para a função executeMethod().
    class LiskovSubstitutionPrinciple
    {
        public class A
        {
            public string getNome()
            {
                return "Meu nome é A"; ;
            }
        }

        public class B : A
        {
            public new string getNome()
            {
                return "Meu nome é B";
            }
        }

        public void imprimeNome(A objeto)
        {
            Console.WriteLine( objeto.getNome());
        }

        public void executeMethod()
        {
            A objeto1 = new A();
            B objeto2 = new B();

            imprimeNome(objeto1);
            imprimeNome(objeto2);
        }
    }
}