using Logic.Interfaces;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class RoomLogic : IRoomLogic
    {
        IRoomRepository roomRepository;
        IThreadsRepository threadsRepository;
        IMessagesRepository messagesRepository;
        IMessagesLogic messagesLogic;
        IThreadsLogic threadsLogic;

        public RoomLogic(IRoomRepository roomRepository, IThreadsRepository threadsRepository, IMessagesRepository messagesRepository, IMessagesLogic messagesLogic, IThreadsLogic threadsLogic)
        {
            this.roomRepository = roomRepository;
            this.threadsRepository = threadsRepository;
            this.messagesRepository = messagesRepository;
            this.messagesLogic = messagesLogic;
            this.threadsLogic = threadsLogic;
        }

        public void AddRoom(Room room)
        {
            this.roomRepository.Add(room);
        }

        public void DeleteRoom(string idRoom)
        {
            this.roomRepository.Delete(idRoom);
        }

        public IQueryable<Room> GetAllRoom()
        {
            return this.roomRepository.GetAll();
        }

        public Room GetOneRoom(string idRoom)
        {
            return this.roomRepository.GetOne(idRoom);
        }

        public void UpdateRoom(Room updatedRoom)
        {
            this.roomRepository.Update(updatedRoom);
        }

        public void AddThreadToRoom(Threads thread, string roomid, string sendername)
        {
            thread.SenderName = sendername;
            thread.TimeStamp = DateTime.Now;
            this.GetOneRoom(roomid).Threads.Add(thread);
            this.roomRepository.Save();
        }

        public void AddUserToRoom(string userid, string roomid)
        {
            Room room = this.GetOneRoom(roomid);
            room.RoomUsers.Add(new RoomUser
            {
                UserID = userid
            });
            this.roomRepository.Save();
        }

        public void RemoveUserFromRoom(string userid, string roomid)
        {
            RoomUser roomuser = this.GetOneRoom(roomid).RoomUsers.FirstOrDefault(ru => ru.UserID == userid);
            if (roomuser != null)
            {
                this.GetOneRoom(roomid).RoomUsers.Remove(roomuser);
                this.roomRepository.Save();
            }
        }

        //Generating data for tests => DONE
        //public void GenerateData()
        //{
        //    Room r1 = new Room() { RoomName = "Projektmunka" };
        //    Room r2 = new Room() { RoomName = "Android fejlesztés alapjai" };

        //    Threads t1 = new Threads() { IsPinned = true, TimeStamp = DateTime.Now, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed fringilla sapien condimentum, lacinia est a, ultricies risus. Vivamus non viverra magna. Nam eleifend nisl vel elementum sodales. Phasellus dictum metus eu vulputate sollicitudin. Quisque luctus nulla eu nibh condimentum commodo. Nunc mollis tellus massa, ac pharetra ante placerat id. Curabitur semper suscipit elit vel varius. Aliquam at elementum velit. Aliquam faucibus ultrices venenatis. Donec porttitor odio sed feugiat fringilla. Vestibulum placerat in nibh id placerat. Curabitur dignissim risus sit amet fringilla porta. Aliquam rutrum orci sed faucibus rhoncus. Phasellus tristique pulvinar mollis." };
        //    Threads t2 = new Threads() { IsPinned = false, TimeStamp = DateTime.Now.AddMinutes(1), Content = "Aliquam ac turpis et urna luctus pharetra. Integer pharetra sagittis nibh, quis aliquet elit. Cras eu velit dictum, commodo dui eu, tincidunt metus. Fusce eget viverra nisi. Sed et congue dolor. Curabitur rutrum semper justo, id commodo eros pellentesque eu. Donec vel porta metus, malesuada suscipit neque. Sed hendrerit libero in nulla placerat gravida. Suspendisse potenti. Quisque cursus scelerisque ultricies. Suspendisse hendrerit, leo sit amet viverra pellentesque, dui mi varius urna, sed consequat ipsum lectus vitae dui. Nunc cursus ut felis vel volutpat. Vivamus est nisl, lacinia blandit mattis id, laoreet a tortor. Integer varius consequat iaculis." };
        //    Threads t3 = new Threads() { IsPinned = true, TimeStamp = DateTime.Now.AddMinutes(2), Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eget nibh vitae lorem posuere facilisis. Aenean scelerisque egestas eros. Quisque vitae venenatis turpis. In tristique felis quis odio sagittis, vitae iaculis libero consequat. Nulla gravida tincidunt dignissim. Sed eleifend erat quis quam suscipit, non tempus sem volutpat. Nunc nec dolor nec tortor suscipit suscipit vitae quis ipsum. Vivamus at arcu finibus, volutpat dui nec, cursus tortor. Morbi efficitur, erat vel congue laoreet, ligula mi auctor mi, vel pharetra turpis ligula a leo. Nulla iaculis tempus velit, auctor cursus mi placerat vitae. Nam enim enim, venenatis posuere molestie ut, aliquet in elit. Morbi eget imperdiet eros. Sed eget lobortis lectus. Nulla eget iaculis massa." };
        //    Threads t4 = new Threads() { IsPinned = false, TimeStamp = DateTime.Now.AddMinutes(3), Content = "Sed finibus suscipit lobortis. Fusce semper mattis magna eget posuere. Curabitur molestie eros metus, a tempor purus varius vel. Nulla leo tellus, suscipit non ligula ac, porta tincidunt urna. Phasellus ut gravida ipsum. Phasellus facilisis sem nunc, feugiat porta justo efficitur vitae. Donec nec ornare ex. Maecenas finibus iaculis nunc ac commodo." };
        //    Threads t5 = new Threads() { IsPinned = false, TimeStamp = DateTime.Now.AddMinutes(4), Content = "Vivamus justo ipsum, ultrices tristique tellus sed, finibus tempor elit. Donec tincidunt vestibulum nisl vehicula viverra. Mauris elementum leo malesuada scelerisque convallis. Donec libero quam, suscipit convallis quam et, tempus mollis enim. Aenean egestas tellus vitae leo sollicitudin, sed placerat neque egestas. Duis in dolor laoreet, vulputate erat scelerisque, ultrices lorem. Nam nisl velit, maximus vel sollicitudin non, tristique nec arcu. Vivamus eget turpis vitae ex eleifend interdum. Suspendisse maximus lorem sed scelerisque tincidunt. Nunc eleifend gravida ante sit amet cursus. Curabitur imperdiet enim id ipsum rutrum, et malesuada velit suscipit. Nulla id nisi arcu. Vivamus libero erat, sagittis vel congue ac, posuere at massa. Fusce eget sem in leo sagittis euismod." };
        //    Threads t6 = new Threads() { IsPinned = false, TimeStamp = DateTime.Now.AddMinutes(5), Content = "Suspendisse neque ex, mollis quis pulvinar ut, blandit nec sem. In vel interdum tortor. Fusce ultrices diam urna, vel iaculis dui ultricies a. Cras at nibh id mi maximus vestibulum id id sem. Aliquam varius venenatis lacus quis convallis. Pellentesque tincidunt sapien tortor, dapibus ullamcorper metus bibendum a. Mauris molestie mi et volutpat tincidunt. Nunc quis dui felis. Mauris faucibus erat at dictum fermentum. Etiam facilisis dignissim tortor, eget faucibus lacus semper vitae. Fusce id neque semper, semper tortor tristique, fringilla tortor. Proin maximus nisl urna, vitae congue justo dictum sit amet. Vestibulum at turpis eget felis tempus convallis. Aenean libero leo, viverra non tempor vel, dignissim et eros. Donec bibendum varius magna ac aliquam." };
        //    Threads t7 = new Threads() { IsPinned = false, TimeStamp = DateTime.Now.AddMinutes(6), Content = "Nulla quis eros sit amet magna iaculis convallis sit amet non nisi. Nunc sodales sagittis arcu sit amet aliquet. Etiam elementum turpis eu mi blandit, quis mollis nunc condimentum. Sed lacinia faucibus lectus. Sed in ipsum euismod nisl imperdiet facilisis. Phasellus porta ligula et mi tempus, non volutpat sem pretium. Duis consectetur metus augue, elementum fringilla lorem consequat sit amet. Cras eu felis magna. Donec facilisis ex neque, id elementum ligula blandit nec." };
        //    Threads t8 = new Threads() { IsPinned = false, TimeStamp = DateTime.Now.AddMinutes(3), Content = "Curabitur vestibulum non urna vitae porta. Curabitur et ipsum quis elit volutpat condimentum. Donec ut varius neque, in gravida ante. Ut laoreet nisi eu augue pellentesque, mollis finibus libero commodo. Nullam a metus iaculis velit dignissim ultrices quis sed eros. Fusce sapien lectus, dapibus at lectus eu, egestas ultrices enim. Praesent ac tellus auctor, posuere mi eget, placerat turpis. Pellentesque elementum turpis quis turpis rutrum pretium. Nulla sed libero feugiat, tincidunt risus a, ultricies nisl. Sed commodo elit sed nunc aliquet viverra." };
        //    Threads t9 = new Threads() { IsPinned = false, TimeStamp = DateTime.Now.AddMinutes(2), Content = "Curabitur non urna vitae porta. Curabitur et ipsum quis elit volutpat condimentum. Donec ut varius neque, in gravida ante. Ut laoreet nisi eu augue pellentesque, mollis finibus libero commodo. Nullam a metus iaculis velit dignissim quis sed eros. Fusce sapien lectus, dapibus at lectus eu, egestas ultrices enim. Praesent ac tellus auctor, posuere mi eget, placerat turpis. Pellentesque elementum turpis quis turpis rutrum pretium. Nulla sed libero feugiat, tincidunt risus a, ultricies nisl. Sed commodo elit sed nunc aliquet viverra." };

        //    Messages m1 = new Messages() { Content = "nice lorem ipsum bro", TimeStamp = DateTime.Now.AddMinutes(10) };
        //    Messages m2 = new Messages() { Content = "we should have mocked some data", TimeStamp = DateTime.Now.AddMinutes(10) };
        //    Messages m3 = new Messages() { Content = "a very nice message for you", TimeStamp = DateTime.Now.AddMinutes(20) };

        //    Reaction reaction1 = new Reaction() { ReactionType = Models.ReactionType.RedHeart};
        //    Reaction reaction2 = new Reaction() { ReactionType = Models.ReactionType.GreenTick };
        //    Reaction reaction3 = new Reaction() { ReactionType = Models.ReactionType.Smile };

        //    AddRoom(r1);
        //    AddRoom(r2);

        //    AddThreadToRoom(t1, r1.RoomID, "kovacs.andras");
        //    AddThreadToRoom(t2, r1.RoomID, "boldi.bihari");
        //    AddThreadToRoom(t3, r1.RoomID, "sipos.miklos"); 
        //    AddThreadToRoom(t4, r1.RoomID, "bogdan.roland");
        //    AddThreadToRoom(t5, r1.RoomID, "tamas.lengyel");
        //    AddThreadToRoom(t6, r2.RoomID, "dariusz.szabo");
        //    AddThreadToRoom(t7, r2.RoomID, "tamas.lengyel");
        //    AddThreadToRoom(t8, r2.RoomID, "kovacs.andras");
        //    AddThreadToRoom(t9, r1.RoomID, "buzasi.simon");

        //    m1.ThreadID = t1.ThreadID;
        //    m2.ThreadID = t5.ThreadID;
        //    m3.ThreadID = t5.ThreadID;

        //    m1.SenderName = "buzasi.simon";
        //    m2.SenderName = "buzasi.simon";
        //    m3.SenderName = "dariusz.szabo";

        //    messagesRepository.Add(m1);
        //    messagesRepository.Add(m2);
        //    messagesRepository.Add(m3);

        //    messagesLogic.AddReactionToMessage(reaction1, m2.MessageID, "kovacs.andras");
        //    threadsLogic.AddReactionToThread(reaction2, t7.ThreadID, "buzasi.simon");
        //    threadsLogic.AddReactionToThread(reaction3, t7.ThreadID, "tamas.lengyel");

        //    this.AddUserToRoom("fc5ddfbf-adbb-485b-9198-d5697f670632", r1.RoomID);
        //    this.AddUserToRoom("cd078415-b771-4375-9079-e0d497567e85", r1.RoomID);
        //    this.AddUserToRoom("70c69d55-28b8-4528-9c27-a4129f12659d", r1.RoomID);
        //    this.AddUserToRoom("cd6687c1-30fb-4a21-b7d9-005986669286", r1.RoomID);
        //    this.AddUserToRoom("cf7d31a0-20a7-4676-8e1f-c69d9470dc76", r1.RoomID);
        //    this.AddUserToRoom("523fdb57-cdc3-4f91-bad8-12e80dfef125", r1.RoomID);
        //    this.AddUserToRoom("796f78d1-9d03-4e0c-bd88-e22338e01425", r1.RoomID);
            
        //    this.AddUserToRoom("fc5ddfbf-adbb-485b-9198-d5697f670632", r2.RoomID);
        //    this.AddUserToRoom("796f78d1-9d03-4e0c-bd88-e22338e01425", r2.RoomID);
        //    this.AddUserToRoom("cf7d31a0-20a7-4676-8e1f-c69d9470dc76", r2.RoomID);
        //}
    }
}
