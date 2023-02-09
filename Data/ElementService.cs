using MudDataGridAndTableSample.Data;

namespace MudDataGridAndTableSample.Data
{
  public class ElementService
  {
    private List<Element> m_elements = Element.GetTestData();

    public Task<IEnumerable<Element>> GetElementAsync()
    {
      return Task.FromResult(m_elements.AsEnumerable());
    }

    public Task<bool> IsExists(Element _element)
    {
      return Task.FromResult(m_elements.IndexOf(_element) != -1);
    }

    public Task<bool> AddElement(Element _element)
    {
      if (0 <= m_elements.IndexOf(_element))
      {
        return Task.FromResult(false);
      }
      m_elements.Add(_element);
      m_elements.Sort();
      return Task.FromResult(true);
    }

    public Task<bool> EditElement(Element _element)
    {
      m_elements.Remove(_element);
      m_elements.Add(_element);
      m_elements.Sort();

      return Task.FromResult(true);
    }

    public Task<bool> DeleteElement(Element _element)
    {
      m_elements.Remove(_element);
      return Task.FromResult(true);
    }
  }
}
