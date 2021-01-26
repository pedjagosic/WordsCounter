using System.Threading;
using System.Threading.Tasks;
using Application.Text.Commands;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public class TestCommandsAndQueries
    {
        [Test]
        public async Task ValidAddTextCommandTest()
        {
            var command = new AddTextCommand("Simple text");
            var validator = new AddTextCommandValidator();
            var validationResult = await validator.ValidateAsync(command, CancellationToken.None);
            Assert.IsTrue(validationResult.IsValid);
        }

        [Test]
        public async Task NotValidTextCommandTest()
        {
            var text =
                @"Consectetur adipiscing elit. Praesent interdum venenatis congue. Vestibulum pellentesque lacus at pulvinar ornare. Proin finibus, nunc ac euismod blandit, turpis lacus lacinia lectus, vel vestibulum ipsum ligula a odio. Proin blandit magna id pharetra mollis. Quisque feugiat elementum purus, ut molestie mauris eleifend vitae. Nam lorem urna, commodo vitae lacus et, varius tristique metus. Pellentesque arcu ipsum, condimentum non hendrerit id, volutpat et ante. Pellentesque faucibus malesuada eros sit amet imperdiet.
Aliquam nec vehicula metus. Suspendisse sed est sagittis, tempus odio ac, mollis nulla. Nullam tincidunt ligula diam, lobortis congue augue vestibulum quis. Mauris consequat finibus venenatis. Vestibulum ultrices, quam et hendrerit varius, massa metus congue purus, eget mattis est metus sit amet magna. Nunc nulla diam, mollis eget eleifend a, congue et tortor. Integer maximus, ante vel fringilla convallis, est turpis posuere nibh, eu fermentum lectus metus in nunc. Sed eu leo scelerisque, convallis nulla a, faucibus justo. Nunc vel gravida nibh. Aenean sagittis nunc massa. Quisque felis erat, maximus mollis justo ultricies, accumsan mollis orci. Suspendisse ullamcorper varius ligula, sit amet auctor felis posuere ut. Curabitur pulvinar placerat erat, sed viverra massa lobortis vel. Etiam nec finibus ex. In elementum, erat eget congue hendrerit, felis nulla malesuada felis, in aliquam urna augue vel orci.
Phasellus eros leo, varius at dui ac, tempus dignissim lectus. Integer vel eleifend augue, ac ullamcorper lectus. Donec accumsan imperdiet augue, eget varius dui porta eget. Curabitur vitae ante congue, elementum purus at, tristique orci. Cras accumsan ultrices eros, a bibendum sem faucibus vitae. Morbi non bibendum lorem. Praesent venenatis velit dapibus odio facilisis semper. Pellentesque at pretium magna. Nunc congue non orci tristique finibus.
Vestibulum ac pretium felis. Nulla viverra ornare diam sed interdum. Maecenas gravida pretium enim vitae auctor. Fusce sit amet ligula at nunc vehicula pharetra. Vivamus et ex sed neque luctus venenatis ut id est. Donec ac eros turpis. Nullam in est et elit tristique consectetur quis at massa. Duis id erat sit amet orci maximus consectetur sit amet quis quam. Praesent sit amet lectus non lectus aliquam viverra id sit amet velit. Donec massa libero, dictum ut nisl a, feugiat congue ante. Vestibulum interdum magna vitae vulputate porta.
Aliquam molestie rhoncus arcu, et ultricies turpis finibus vel. Praesent vel tortor nisl. Nulla accumsan, lorem nec finibus tincidunt, lorem felis faucibus nibh, vel vulputate purus elit vel sem. In pulvinar dapibus blandit. Sed accumsan diam ultrices dolor semper, vel commodo est viverra. Maecenas dignissim quam sed diam tincidunt, eget volutpat felis congue. Fusce mollis erat at sagittis cursus. Nulla feugiat, lacus sed tempus mollis, eros ex ornare metus, sit amet molestie urna nulla rutrum ipsum. Aenean tristique magna vitae iaculis feugiat.
Ut vehicula cursus eros, sit amet tempus ipsum iaculis lobortis. In finibus aliquam laoreet. Nulla ut vehicula diam, ac accumsan dolor. Pellentesque sodales dignissim ultrices. Integer dignissim vitae nunc eu porttitor. Maecenas cursus massa vitae consequat consequat. Etiam vel fringilla elit, eu posuere nulla. Nam tempus nisi in lectus consequat, ac sagittis neque imperdiet. Maecenas velit urna, congue at lorem non, pulvinar laoreet magna. Quisque iaculis sollicitudin mattis. Proin ullamcorper placerat velit non accumsan. Sed ullamcorper nibh a ante porta iaculis. Praesent vestibulum, metus ut pretium tincidunt, nunc purus porttitor sem, quis tempor lacus elit id metus. Vivamus metus odio, porttitor a quam eget, rhoncus congue purus. Sed imperdiet nisi nunc, id consequat lacus ultrices a. Vivamus posuere, est a faucibus hendrerit, leo risus aliquet velit, in sollicitudin nunc magna eget metus.
Suspendisse id facilisis orci. Cras commodo feugiat sem et lobortis. Vestibulum elementum semper eros quis suscipit. Vivamus turpis urna, viverra a dui ac, convallis eleifend libero. Fusce in eros ac justo ullamcorper tincidunt sed vitae odio. Praesent ac tortor lobortis, consectetur ipsum eu, ultrices leo. Phasellus dolor magna, iaculis in rutrum at, porta in purus. Vestibulum a ipsum erat. Donec egestas vel quam eget dictum. Suspendisse potenti.";

            var command = new AddTextCommand(text);
            var validator = new AddTextCommandValidator();
            var validationResult = await validator.ValidateAsync(command, CancellationToken.None);
            Assert.IsTrue(!validationResult.IsValid);
        }
    }
}