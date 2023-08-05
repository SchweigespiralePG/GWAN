using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DropDownPopulator : MonoBehaviour
{
    public JsonDataReader jsonDataReader;
    public Dropdown dropdown;
    public Text additionalInfoText;

    private void Start()
    {
        PopulateDropdown();
    }

    void PopulateDropdown()
    {
        dropdown.ClearOptions();

        //입력받은 JSON 파일들의 Name으로 드롭다운 리스트에 추가하기
        var dropdownOptions = new List<string>();
        foreach (DataEntry entry in jsonDataReader.dataEntries)
        {
            dropdownOptions.Add(entry.Tag);
            Debug.Log("Dropdown Options Count: " + dropdownOptions.Count);
        }

        dropdown.AddOptions(dropdownOptions);
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        OnDropdownValueChanged(0);
    }
    void OnDropdownValueChanged(int index)
    {
        // Check if the dataEntries list is null or empty before accessing it.
        if (jsonDataReader.dataEntries == null || jsonDataReader.dataEntries.Length == 0)
        {
            Debug.LogError("No data loaded from JSON files. Please make sure the JSON files are correctly placed and formatted.");
            return;
        }

        // Ensure that the index is within the valid range.
        if (index < 0 || index >= jsonDataReader.dataEntries.Length)
        {
            Debug.LogError("Invalid index in dropdown selection.");
            return;
        }

        // Implement how you want to handle the selected data entry.
        // You can access the full DataEntry object using jsonDataReader.dataEntries[index] if needed.
        Debug.Log("Selected Entry: " + dropdown.options[index].text);
        // Debug.Log("Name: " + jsonDataReader.dataEntries[index].Name);
    }
}