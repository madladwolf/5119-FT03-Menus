using System.Linq;

namespace _5119_FT03
{
    class Contacto
    {
        private string nome, telef, email;
        private int id;
        public Data DataNasc { get; set; }
        public Contacto()
        {
            id = 0;
            nome = "Pessoa";
            telef = "+351999999999";
            email = "sem@email.com";
            DataNasc = new Data();
        }

        public Contacto(int id,string nome, string telef, string email, Data datan)
        {
            if (!setID(id)) this.id = id;
            if (!setNome(nome)) this.nome = "Pessoa";
            if (!setTelef(telef)) this.telef = "+35199999999";
            if (!setEmail(email)) this.email = "sem@emai.com";
            DataNasc = new Data(datan);
        }

        public Contacto(Contacto c1)
        {
            id = c1.getId();
            nome = c1.getNome();
            telef = c1.getTelef();
            email = c1.getEmail();
            DataNasc = new Data(c1.DataNasc);
        }

        public string getNome()
        {
            return nome;
        }

        public string getTelef()
        {
            return telef;
        }

        public string getEmail()
        {
            return email;
        }

        public bool setID(int a)
        {
            if(id > 0)
            {
                id = a;
                return true;
            }
            return false;

        }

        public int getId()
        {
            return id;
        }

        public int calcIdade()
        {
            return 2019 - DataNasc.getAno();
        }

        public bool setNome(string nome)
        {
            if (nome != "" && nome != null)
            {
                this.nome = nome;
                return true;
            }
            return false;
        }

        public bool setTelef(string telef)
        {
            if (telef.Length == 12)
            {
                this.telef = telef;
                return true;
            }
            return false;
        }

        public bool setEmail(string email)
        {
            bool result = true;
            int count = email.Count(f => f == '@');
            if (count == 0)
            {
                return false;
            }
            if (count > 1)
            {
                return false;
            }
            count = email.Count(f => f == '.');
            if (count == 0)
            {
                return false;
            }
            if (count > 1)
            {
                return false;
            }
            string theChar = email.Split('@')[1].ToString();
            int theCharLen = theChar.Split('.')[0].ToString().Length;
            if (theCharLen < 2)
            {
                result = false;
            }
            this.email = email;
            return result;

        }


        public override string ToString()
        {
            return id + " - " + nome + " - " + telef + " - " + email + " - " + DataNasc;
        }
    }
}
