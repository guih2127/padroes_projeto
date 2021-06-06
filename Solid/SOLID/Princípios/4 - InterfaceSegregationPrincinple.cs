namespace SOLID.Princípios
{
    class InterfaceSegregationPrincinple
    {
        interface Aves
        {
            public void setLocalizacao(int longitude, int latitude);
            public void setAltitude(int altitude);
            public void renderizar();
        }

        class Papagaio : Aves
        {
            public void setLocalizacao(int longitude, int latitude)
            {
                //Faz alguma coisa
            }

            public void setAltitude(int altitude)
            {
                //Faz alguma coisa   
            }

            public void renderizar()
            {
                //Faz alguma coisa
            }
        }

        class Pinguim : Aves
        {
            public void setLocalizacao(int longitude, int latitude)
            {
                //Faz alguma coisa
            }

            // A Interface Aves está forçando a Classe Pinguim a implementar esse método.
            // Isso viola o príncipio ISP
            public void setAltitude(int altitude)
            {
                //Não faz nada...  Pinguins são aves que não voam!
            }

            public void renderizar()
            {
                //Faz alguma coisa
            }
        }


        /*--------------------------- IMPLEMENTAÇÃO CORRETA ----------------------------*/
        interface AvesRefatorado
        {
            public void setLocalizacao(int longitude, int latitude);
            public void renderizar();
        }

        interface AvesQueVoam : AvesRefatorado
        {
            public void setAltitude(int altitude);
        }   

        class PapagaioRefatorado : AvesQueVoam
        {
            public void setLocalizacao(int longitude, int latitude)
            {
                //Faz alguma coisa
            }

            public void setAltitude(int altitude)
            {
                //Faz alguma coisa   
            }

            public void renderizar()
            {
                //Faz alguma coisa
            }
        }

        class PinguimRefatorado : AvesRefatorado
        {
            public void setLocalizacao(int longitude, int latitude)
            {
                //Faz alguma coisa
            }

            public void renderizar()
            {
                //Faz alguma coisa
            }
        }
    }
}
