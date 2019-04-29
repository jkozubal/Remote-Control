
namespace RemoteInvitesControl
{
    public class RemoteControlConfigModel
    {
        public bool RemoteControlEnabled;
        public int TimeOfInvitation;
        public string UnitOfTime;
        public bool OnlyVistaOrNewerEnabled;

        public RemoteControlConfigModel(bool isRemote, int time, string timeUnit, bool isVista)
        {
            RemoteControlEnabled = isRemote;
            TimeOfInvitation = time;
            UnitOfTime = timeUnit;
            OnlyVistaOrNewerEnabled = isVista;
        }
        public RemoteControlConfigModel()
        {

        }
    }
}
