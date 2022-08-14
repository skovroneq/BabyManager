using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyManager
{
    public class RecordService
    {
        public List<Record> Records { get; set; }

        public RecordService()
        {
            Records = new List<Record>();
        }

        public ConsoleKeyInfo AddNewRecordView(MenuActionService actionService)
        {
            var addNewRecordMenu = actionService.GetMenuActionsByMenuName("AddNewRecordMenu");
            Console.WriteLine("\nPlease select record type:");
            for (int i = 0; i < addNewRecordMenu.Count; i++)
            {
                Console.WriteLine($"{addNewRecordMenu[i].Id}. {addNewRecordMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            return operation;
        }

        public int AddNewRecord(char recordType)
        {
            int recordTypeId;
            Int32.TryParse(recordType.ToString(), out recordTypeId);
            Record record = new Record();
            record.TypeId = recordTypeId;
            Console.WriteLine("\nPlease enter id for new record:");
            var id = Console.ReadLine();
            int recordId;
            Int32.TryParse(id, out recordId);
            Console.WriteLine("Please enter date for new record:");
            var date = Console.ReadLine();
            var startTime = "-";
            var endTime = "-";

            if (recordTypeId == 1 || recordTypeId == 2)
            {
                Console.WriteLine("Please enter start time for new record:");
                startTime = Console.ReadLine();
                Console.WriteLine("Please enter end time for new record:");
                endTime = Console.ReadLine();
            }

            record.Id = recordId;
            record.Date = date;
            record.StartTime = startTime;
            record.EndTime = endTime;

            Records.Add(record);
            return recordId;
        }

        public int RemoveRecordView()
        {
            Console.WriteLine("\nPlease enter id for record you want to remove:");
            var recordId = Console.ReadLine();
            int removeId;
            Int32.TryParse(recordId.ToString(), out removeId);

            return removeId;
        }

        public void RemoveRecord(int removeId)
        {
            Record recordToRemove = new Record();
            foreach (var record in Records)
            {
                if (record.Id == removeId)
                {
                    recordToRemove = record;
                    break;
                }
            }
            Records.Remove(recordToRemove);
        }

        public int RecordTypeSelectionView()
        {
            Console.WriteLine("\nPlease enter Type Id for record type you want to show:");
            var recordId = Console.ReadKey();
            int id;
            Int32.TryParse(recordId.KeyChar.ToString(), out id);

            return id;
        }

        public void RecordsByTypeIdView(int typeId)
        {
            List<Record> recordsToShow = new List<Record>();
            foreach (var record in Records)
            {
                if (record.TypeId == typeId)
                {
                    recordsToShow.Add(record);
                }
            }

            for (int i = 0; i < recordsToShow.Count; i++)
            {
                Console.WriteLine($"\nID: {recordsToShow[i].Id}");
                Console.WriteLine($"Date: {recordsToShow[i].Date}");
                Console.WriteLine($"Start time: {recordsToShow[i].StartTime}");
                Console.WriteLine($"End time: {recordsToShow[i].EndTime}");
            }
        }
        public string RecordDateSelectionView()
        {
            Console.WriteLine("\nPlease enter date for records you want to show:");
            var date = Console.ReadLine();
            
            return date;
        }

        public void RecordsByDateView(string dateSelected)
        {
            List<Record> recordsToShowByDate = new List<Record>();
            foreach (var record in Records)
            {
                if (record.Date == dateSelected)
                {
                    recordsToShowByDate.Add(record);
                }
            }

            for (int i = 0; i < recordsToShowByDate.Count; i++)
            {
                Console.WriteLine($"\nID:{recordsToShowByDate[i].Id}");
                Console.WriteLine($"Date: {recordsToShowByDate[i].Date}");
                Console.WriteLine($"Start time: {recordsToShowByDate[i].StartTime}");
                Console.WriteLine($"End time: {recordsToShowByDate[i].EndTime}");
            }
        }
    }
}
