namespace SOLID.Princípios
{
    public class DependencyInversionPrinciple
    {
        // Aqui temos um exemplo de um código com alto acoplamento. Por que?
        // Para utilizarmos a classe PasswordReminder e recuperarmos a senha, precisamos conectar no banco.
        // Aqui, fazemos isso no nosso construtor, instanciando o DbConnection nele para realizar as operações.
        // Como a classe PasswordReminder tem a RESPONSABILIDADE de instanciar a classe MySqlConnection, fazemos com que
        // o nível de acoplamento seja alto. Se quisessemos reaproveitar essa classe em outro sistema, teriamos obrigatoriamente
        // de levar a classe MySqlConnection junto, portanto, temos um forte acoplamento aqui.
        class MySqlConnection { };
        class PasswordReminder
        {
            private MySqlConnection _DbConnection { get; set; }

            public PasswordReminder()
            {
                this._DbConnection = new MySqlConnection();
            }
        }

        // Nosso código refatorado faz com que a criação da instância de MySqlConnection deixe de ser da própria classe.
        // Agora, a classe de banco de dados virou uma dependência que deve ser injetada via construtor. Aqui temos o conceito de 
        // injeção de dependência sendo aplicado.
        // Porém, nosso código ainda não está bom. Ainda violamos o conceitos do DIP, pois estamos dependendo de uma implementação
        // e não de uma abstração.
        // O DIP dita que tanto os módulos de baixo quanto os de alto nível devem depender de abstrações. Aqui, o módulo de alto nível
        // é PasswordReminder e o de baixo nível é o MySqlConnection. Como MySqlConnection é uma implementação e não uma abstração, estamos
        // violando o DIP.
        class PasswordReminderRefatored
        {
            private MySqlConnection _DbConnection { get; set; }

            public PasswordReminderRefatored(MySqlConnection dbConnection)
            {
                _DbConnection = dbConnection;
            }
        }

        // Por último, agora nosso código não depende mais de implementações e apenas de abstrações. A classe PasswordReminder não faz ideia de qual banco de dados a aplicação irá utilizar.
        // Dessa forma, não violamos mais o DIP, ambas as classes estão desaclopadas e dependendo de uma abstração.

        interface DbConnectionInterface
        {
            public void Connect();
        }

        class MySqlConnectionRefatored : DbConnectionInterface
        {
            public void Connect() 
            { 
                // faz algo 
            }
        }

        class OracleConnectionRefatored : DbConnectionInterface
        {
            public void Connect()
            {
                // faz algo
            }
        }

        class PasswordReminderRefatored2
        {
            private DbConnectionInterface _DbConnection { get; set; }

            public PasswordReminderRefatored2(DbConnectionInterface dbConnection)
            {
                _DbConnection = dbConnection;
            }
        }
    }
}