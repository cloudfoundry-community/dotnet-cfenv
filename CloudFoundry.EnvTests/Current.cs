using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.Env;

namespace CloudFoundry.EnvTests
{
    [TestClass]
    public class Current
    {
        /// <summary>
        /// Tee up the environment to look like a CF
        /// </summary>
        public void LookLikeTheCF()
        {
            Environment.SetEnvironmentVariable(Constants.INSTANCE_INDEX_ENV_VARIABLE_NAME, "0");
            Environment.SetEnvironmentVariable(Constants.INSTANCE_GUID_ENV_VARIABLE_NAME, "30e7c283-6ee4-4000-7041-89c73713eca2");
            Environment.SetEnvironmentVariable(Constants.IP_ENV_VARIABLE_NAME, "192.168.3.241");
            Environment.SetEnvironmentVariable(Constants.PORT_ENV_VARIABLE_NAME, "55731");
            Environment.SetEnvironmentVariable(Constants.APPLICATION_ENV_VARIABLE_NAME, "{\"limits\":{\"mem\":512,\"disk\":1024,\"fds\":16384},\"application_id\":\"010629ed-33a0-44d6-9ffa-bf3514acfd8d\",\"application_version\":\"940fad7a-49a9-4fc0-b772-4df639a5e268\",\"application_name\":\"env\",\"application_uris\":[\"env.apps.410er.com\"],\"version\":\"940fad7a-49a9-4fc0-b772-4df639a5e268\",\"name\":\"env\",\"space_name\":\"development\",\"space_id\":\"62f87209-c313-44ce-8112-e65d6aabd40a\",\"uris\":[\"env.apps.410er.com\"]}");
        }

        [TestMethod]
        public void TestSingleInstanceOfPivotalMySQL()
        {
            LookLikeTheCF();
            Environment.SetEnvironmentVariable(Constants.BOUND_SERVICES_ENV_VARIABLE_NAME, "{ \"p-mysql\": [ { \"name\": \"mysql\", \"label\": \"p-mysql\", \"tags\": [ \"mysql\", \"relational\" ], \"plan\": \"100mb-dev\", \"credentials\": { \"hostname\": \"192.168.3.73\", \"port\": 3306, \"name\": \"cf_86f01461_0a51_4b26_bb5d_1ec525f58d0f\", \"username\": \"kJg8ssKUPWygS73R\", \"password\": \"qGI0vwS5NOAu7zRl\", \"uri\": \"mysql://kJg8ssKUPWygS73R:qGI0vwS5NOAu7zRl@192.168.3.73:3306/cf_86f01461_0a51_4b26_bb5d_1ec525f58d0f?reconnect=true\", \"jdbcUrl\": \"jdbc:mysql://192.168.3.73:3306/cf_86f01461_0a51_4b26_bb5d_1ec525f58d0f?user=kJg8ssKUPWygS73R&password=qGI0vwS5NOAu7zRl\" } } ] }");

            // Check services
            Assert.AreEqual<int>(1, Env.Current.Services.Count);
            Assert.AreEqual<string>("p-mysql", Env.Current.Services[0].ServiceName);
            Assert.AreEqual<string>("mysql", Env.Current.Services[0].BindingName);
            Assert.AreEqual<int>(7, Env.Current.Services[0].Credentials.Count);
            Assert.AreEqual<string>("p-mysql", Env.Current.Services[0].Label);
            Assert.AreEqual<string>("100mb-dev", Env.Current.Services[0].Plan);
            Assert.AreEqual<int>(2, Env.Current.Services[0].Tags.Count);

            // check application
            Assert.AreEqual<string>("env", Env.Current.AppName);
            Assert.AreEqual<string>("010629ed-33a0-44d6-9ffa-bf3514acfd8d", Env.Current.ID);
            Assert.AreEqual<string>("940fad7a-49a9-4fc0-b772-4df639a5e268", Env.Current.AppVersion);
            Assert.AreEqual<int>(0, Env.Current.Index);
            Assert.AreEqual<string>("192.168.3.241", Env.Current.IP);
            Assert.AreEqual<int>(55731, Env.Current.Port);
            Assert.AreEqual<int>(512, Env.Current.MemoryLimit);
            Assert.AreEqual<int>(1024, Env.Current.DiskLimit);
            Assert.AreEqual<string>("development", Env.Current.SpaceName);
            Assert.AreEqual<string>("62f87209-c313-44ce-8112-e65d6aabd40a", Env.Current.SpaceID);
            Assert.IsNotNull(Env.Current.Uris);
            Assert.AreEqual<int>(1, Env.Current.Uris.Count);
       
        }
    }
}
