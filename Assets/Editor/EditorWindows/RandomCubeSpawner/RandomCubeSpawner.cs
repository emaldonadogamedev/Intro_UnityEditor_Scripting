using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomCubeSpawner : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    private Button runTaskButton;

    private ProgressBar m_runTaskProgressBar;

    private float m_progress = 0f;

    [MenuItem("My Tools/RandomCubePlacer")]
    public static void ShowExample()
    {
        RandomCubeSpawner wnd = GetWindow<RandomCubeSpawner>();
        wnd.titleContent = new GUIContent("RandomCubeSpawner");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);

        runTaskButton = root.Q<Button>("RunTaskButton");
        runTaskButton.clicked += RunTaskAsync;

        m_runTaskProgressBar = root.Q<ProgressBar>();
        m_runTaskProgressBar.title = "";
    }

    private async void RunTaskAsync()
    {
        m_progress = 0f;
        m_runTaskProgressBar.value = 0f;
        m_runTaskProgressBar.title = "";

        runTaskButton.SetEnabled(false);

        GameObject parentGO = new("RandomCubes_Parent");

        while (m_progress < 100f)
        {
            await Task.Delay(100);

            m_progress += 1.0f;

            m_runTaskProgressBar.value = m_progress;

            m_runTaskProgressBar.title = "running task";

            AddNewCubeInRandomPosition(parentGO.transform);
        }

        m_runTaskProgressBar.title = "Done!";

        runTaskButton.SetEnabled(true);
    }

    private void AddNewCubeInRandomPosition(Transform parentTransform)
    {
        var newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        newCube.transform.position = new Vector3(
            Random.Range(-20f, 20f),
            0f,
            Random.Range(-20f, 20f));

        newCube.transform.SetParent(parentTransform);
    }
}