public interface ITower
{
    public string TowerName { get; set; }
    public string Price { get; set; }
    public string Range { get; set; }
    public string ShottingSpeed { get; set; }
    public void Initialize();
}
