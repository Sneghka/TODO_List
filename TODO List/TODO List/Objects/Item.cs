namespace TODO_List.Objects
{
    public class Item
    {
        public string Name {  get; set; }
        public bool IsDone { get; set; }
        public int Id { get; set; }

        public Item() { }

        public Item(int id, string name, bool isDone) {
            this.Id = id;
            this.Name = name;
            this.IsDone = isDone;
        }
    }
}
