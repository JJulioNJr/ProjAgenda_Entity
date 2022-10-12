using AgendaEntity.Context;
using AgendaEntity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaEntity.Controllers {
    internal class PersonController {
        #region Insere Dados
        public void InsertPerson() {
            Console.Clear();
            Console.WriteLine("\n*** Cadastrar Pessoas ***");

            using (var context = new TableContext()) {
                
                Person person = new Person();
                Console.Write("\nNome: ");
                person.Name = Console.ReadLine().ToUpper();
                Console.Write("\nEmail: ");
                person.Email = Console.ReadLine();
                Console.Write("\nIdade: ");
                person.Idade = Console.ReadLine();
                context.Persons.Add(person);
                context.SaveChanges();

                Console.WriteLine("\nPessoa Cadastrada com Sucesso...");
                Thread.Sleep(2000);
            }
        }

        #endregion

        #region Lista Todos
        public void ListPerson() {
            Console.Clear();
            Console.WriteLine("\n*** Consulta de Pessoas ***");
            using (var context = new TableContext()) {
                var persons = new TableContext().Persons.ToList();
                foreach (var item in persons) {
                    Console.WriteLine(item.ToString());
                }
            }

            Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
            Console.ReadKey();
        }
        #endregion

        #region Listar Unico
        public void UniquePerson() {
            Console.Clear();
            using (var context = new TableContext()) {
                Console.WriteLine("\n*** Localizar Pessoa ***");
                Console.Write("\nNome: ");
                string name = Console.ReadLine().ToUpper();
                Person find = new TableContext().Persons.Find(name);
                if (find != null) {
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                }
                else {
                    Console.WriteLine("\nPessoa Não Encontrada...");
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                }
            }
         
        }
        #endregion

        #region Remove
        public void RemoverPerson() {
            Console.Clear();
            using (var context = new TableContext()) {
                Console.WriteLine("\n*** Remover Cadastrado ***");
                Console.Write("\nNome: ");
                string name = Console.ReadLine().ToUpper();
                Person find = new TableContext().Persons.Find(name);
                if (find != null) {
                    context.Entry(find).State = EntityState.Deleted;
                    context.Persons.Remove(find);
                    context.SaveChanges();
                    Console.WriteLine("\nPessoa Removida com Sucesso...");
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                }
                else {
                    Console.WriteLine("\nPessoa Não Encontrada...");
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                }
            }
        }
        #endregion

        #region Update
        public void UpdatePerson() {
            Console.Clear();
            using (var context = new TableContext()) {
                Console.WriteLine("\n*** ALterar Campos ***");
                Console.Write("\nDigite o Nome da Pessoa Que Deseja Alterar os Campos: ");
                Console.Write("\nNome:");
                string name = Console.ReadLine().ToUpper();
                Person find = new TableContext().Persons.Find(name);
                if (find != null) {
                    context.Entry(find).State = EntityState.Modified;
                    Console.Write("\nAlterar Email: ");
                    find.Email = Console.ReadLine();
                    Console.Write("\nAltere Idade: ");
                    find.Idade = Console.ReadLine();
                    context.SaveChanges();
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("\nPessoa Alterada com Sucesso...");
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                }
                else {
                    Console.WriteLine("\nPessoa Não Encontrada...");
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                }
            }

        }
        #endregion

        #region Menu Person
        public void MenuPerson() {
            int op;
            do {
                Console.WriteLine("\n\t\t*** Menu Perssoas***");
                Console.WriteLine("\n1-Cadastrar Pessoas" +
                                  "\n2-Consultar Pessoas" +
                                  "\n3-Localizar Pessoa" +
                                  "\n4-Remover Pessoa" +
                                  "\n5-Editar Pessoa" +
                                  "\n0-Voltar ao Menu Inicial");
                Console.Write("\nDigitar: ");
                op = int.Parse(Console.ReadLine());

                switch (op) {
                    case 0:
                        Console.Clear();
                        break;
                    case 1:
                        InsertPerson();
                        Console.Clear();

                        break;
                    case 2:
                        ListPerson();
                        Console.Clear();

                        break;
                    case 3:
                        UniquePerson();
                        Console.Clear();

                        break;
                    case 4:
                        RemoverPerson();
                        Console.Clear();
                        break;
                    case 5:
                        UpdatePerson();
                        Console.Clear();
                        break;
                    default:
                        if (op < 0 || op > 5) {

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
