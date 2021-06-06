namespace SOLID.Princípios
{
    class OpenClosedPrinciple
    {
        // Nesse exemplo, temos um sistema hipotético de RH, onde temos duas classes que representam os contratos
        // de trabalhos de funcionários de uma pequena empresa, estagiários ou contratados. A classe folha de pagamento
        // precisa verificar o tipo do funcionário e, então, aplicar a regra de negócio correta.

        // Porém, imagine que agora precisamos lidar com trabalhadores PJ na nossa empresa.
        // A solução mais fácil seria adicionar mais um IF, porém ela não é a mais correta, já que ao alterar uma classe já existente
        // para adicionar um novo comportamento corremos sérios riscos de introduzir bugs à algo que já funciona.

        // O OCP preza que uma classe deve estar FECHADA para alteração e ABERTA para extensão.
        // Para adicionarmos um novo comportamento sem alterar a classe, devemos separar o comportamento extensível por trás e uma interface
        // e inverter as dependências.

        class ContratoClt
        {
            public void salario()
            {
                //...
            }
        }

        class Estagio
        {
            public void bolsaAuxilio()
            {
                //...
            }
        }

        class FolhaDePagamento
        {
            protected int saldo;

            public void calcular(dynamic funcionario)
            {
                if (funcionario.GetType() == typeof(ContratoClt))
                    this.saldo = funcionario.salario();
                else if (funcionario.GetType() == typeof(Estagio))
                    this.saldo = funcionario.bolsaAuxilio();
            }
        }

        // Como estamos lidando com remuneração de contratos de trabalho, aplicando conceitos de se isolar o comportamento extensível
        // através de uma interface, criamos uma interface Remuneravel

        interface Remuneravel
        {
            public int remuneracao();
        }

        class ContratoCltRefatored : Remuneravel
        {
            public int remuneracao()
            {
                return 0;
            }
        }

        class EstagioRefatored : Remuneravel
        {
            public int remuneracao()
            {
                return 0;
            }
        }

        class FolhaDePagamentoRefatored
        {
            protected int saldo;
    
            public void calcular(Remuneravel funcionario)
            {
                this.saldo = funcionario.remuneracao();
            }
        }

        // Retiramos a responsabilidade da classe folha de pagamento e, agora, para cada nova regra que precisarmos implemementar,
        // É necessário criar uma nova classe EXTENDENDO a interface Remuneravel, NÃO SENDO NECESSÁRIO ATERAR O CÓDIGO JÁ EXISTENTE.
    }
}
