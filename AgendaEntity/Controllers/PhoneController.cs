using AgendaEntity.Context;
using AgendaEntity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaEntity.Controllers {
    internal class PhoneController {

        #region Insere Dados
        public void InsertPhone() {
            Console.WriteLine("\n*** Cadastrar Telefones ***");
            TelephoneBook phone = new TelephoneBook();
            Console.Write("\nNome: ");
            String nome = Console.ReadLine();

            Person find = new TableContext().Persons.Find(nome);
            if (find != null) {
                using (var context1 = new TableContext()) {
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("\n*** Cadastrar Telefones ***");
                    phone.NameId = nome;
                    Console.Write("\nTelefone: ");
                    phone.Phone = Console.ReadLine();
                    Console.Write("\nCelular: ");
                    phone.Mobile = Console.ReadLine();
                    context1.Phones.Add(phone);
                    context1.SaveChanges();
                    Console.WriteLine("\nTelefone Cadastrados com Sucesso...");
                    Thread.Sleep(2000);

                }

            }
            else {
                Console.WriteLine("\nPessoa Não Encontrada...");
                Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                Console.ReadKey();
            }
        }
        #endregion

        #region Lista Todos
        public void ListPhone() {
            Console.Clear();
            Console.WriteLine("\n*** Consulta de Telefones ***");
            using (var context = new TableContext()) {
                var phones = new TableContext().Phones.ToList();
                foreach (var item in phones) {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                }
            }
        }
        #endregion

        #region Listar Unico
        public void UniquePhone() {
            Console.Clear();
            using (var context = new TableContext()) {
                Console.WriteLine("\n*** Localizar Telefones ***");
                Console.Write("\nId: ");
                int id = int.Parse(Console.ReadLine());
                TelephoneBook find = new TableContext().Phones.Find(id);
                if (find != null) {
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();

                }
                else {
                    Console.WriteLine("\nTelefones Não Encontrados...");
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                }
            }

        }
        #endregion

        #region Remove
        public void RemoverPhone() {
            Console.Clear();
            using (var context = new TableContext()) {
                Console.WriteLine("\n*** Remover Telefones ***");
                Console.Write("\nId: ");
                int id = int.Parse(Console.ReadLine());
                TelephoneBook find = new TableContext().Phones.Find(id);
                if (find != null) {
                    context.Entry(find).State = EntityState.Deleted;
                    context.Phones.Remove(find);
                    context.SaveChanges();
                    Console.WriteLine("\nTelefones Removidos com Sucesso...");
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                }
                else {
                    Console.WriteLine("\nTelefones Não Encontrados...");
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                }
            }

        }
        #endregion

        #region Update
        public void UpdatePhone() {
            Console.Clear();
            using (var context = new TableContext()) {
                Console.WriteLine("\n*** ALterar Telefones ***");
                Console.Write("\nId: ");
                int id = int.Parse(Console.ReadLine());
                TelephoneBook find = new TableContext().Phones.Find(id);
              
                if (find != null) {
                    context.Entry(find).State = EntityState.Modified;
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("\n*** ALterar Telefones ***");
                    Console.Write("\nAlterar Telefone: ");
                    find.Phone = Console.ReadLine();
                    Console.Write("\nAlterar Celular: ");
                    find.Mobile = Console.ReadLine();
                    context.SaveChanges();
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("\nTelefones Editados Com Sucesso...");
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                }
                else {
                    Console.WriteLine("\nTelefones Não Encontrados...");
                    Console.WriteLine("\nPressione Qualquer Tecla Para Continuar...");
                    Console.ReadKey();
                }
            }
        }
        #endregion

        #region Menu Phone
        public void MenuPhone() {
            int op;
            do {
                Console.WriteLine("\n\t\t*** Menu Telefones***");
                Console.WriteLine("\n1-Cadastrar Telefone" +
                                  "\n2-Consultar Telefone" +
                                  "\n3-Localizar Telefone" +
                                  "\n4-Remover Telefone" +
                                  "\n5-Editar Telefone" +
                                  "\n0-Voltar ao Menu Inicial");
                Console.Write("\nDigitar: ");
                op = int.Parse(Console.ReadLine());

                switch (op) {
                    case 0:
                        Console.Clear();
                        break;
                    case 1:
                        InsertPhone();
                        Console.Clear();

                        break;
                    case 2:
                        ListPhone();
                        Console.Clear();

                        break;
                    case 3:
                        UniquePhone();
                        Console.Clear();

                        break;
                    case 4:
                        RemoverPhone();
                        Console.Clear();
                        break;
                    case 5:
                        UpdatePhone();
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
