using DbUp;
using DbUp.Engine;
using System.Reflection;

namespace DatabaseVersioning
{
    public static class DbVersioning
    {
        public static bool Execute(string connectionString)
        {
            UpgradeEngine upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            DatabaseUpgradeResult result = upgrader.PerformUpgrade();

            return result.Successful;
        }
    }
}
