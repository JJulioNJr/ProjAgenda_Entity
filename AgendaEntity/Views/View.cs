using AgendaEntity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaEntity.Views {
    public  class View {


        public View() { }

        #region Menu Principal
        public static void Menu() {
            PersonController person = new PersonController();
            PhoneController phone = new PhoneController();
            int op = 0;

            do {
                Console.WriteLine("\n\t\t*** Menu ***");
                Console.WriteLine("\n1-Cadastrar Pessoas" +
                                  "\n2-Cadastrar Telefones" +
                                  "\n0-Sair do Sistema");
                Console.Write("\nDigitar: ");
                op = int.Parse(Console.ReadLine());

                switch (op) {
                    case 1:
                        Console.Clear();
                        person.MenuPerson();
                        break;
                    case 2:
                        Console.Clear();
                        phone.MenuPhone();
                        break;

                    default:
                        if (op < 0 || op > 2) {

                            Console.WriteLine("\nOpção Invalida!!!");
                            Thread.Sleep(3000);
                            Console.Clear();
                        }
                        break;
                }
            } while (op != 0);
        }
        #endregion

    }
}
