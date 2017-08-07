using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace FileStream_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            FileStream fin = null;
            try
            {
                fin = new FileStream("c:\\temp\\test.txt", FileMode.Open);

              FileSecurity AC =   fin.GetAccessControl();
              AuthorizationRuleCollection ACLs =   AC.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
                foreach (FileSystemAccessRule ACL in ACLs)
                {
                    Console.WriteLine("Account : " + ACL.IdentityReference.Value);
                    Console.WriteLine("Type : " + ACL.AccessControlType);
                    Console.WriteLine("Rights : " + ACL.FileSystemRights);
                    Console.WriteLine("Inherited ACE : " + ACL.IsInherited);
                    Console.WriteLine("========================================================\n");


                }

            }
            catch (IOException exc)
            { // catch all I/O exceptions
                Console.WriteLine(exc.Message);
                // Handle the error.
            }
            catch (Exception exc)
            { // catch any other exception
                Console.WriteLine(exc.Message);
                // Handle the error, if possible.
                // Rethrow those exceptions that you don't handle.
            }
            Console.Read();
        }
    }
}
