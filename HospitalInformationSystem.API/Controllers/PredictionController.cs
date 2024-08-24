using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

[Route("api/[controller]")]
[ApiController]
public class PredictionController : ControllerBase
{
    private readonly InferenceSession _heartsession;
    private readonly InferenceSession _covidsession;
    private readonly InferenceSession _diabeticsession;



    public PredictionController()
    {
        _heartsession = new InferenceSession("C:\\Users\\c.delivery for lap\\source\\repos\\HospitalInformationSystem\\HospitalInformationSystem.API\\PyHeart\\simple_nn (1).onnx");
        _covidsession = new InferenceSession("C:\\Users\\c.delivery for lap\\source\\repos\\HospitalInformationSystem\\HospitalInformationSystem.API\\PyCovid\\simple2_nn.onnx");
        _diabeticsession = new InferenceSession("C:\\Users\\c.delivery for lap\\source\\repos\\HospitalInformationSystem\\HospitalInformationSystem.API\\PyDiabtes\\simple3_nn.onnx");


    }


    [HttpPost("PredictHeart")]
    public IActionResult PredictHeart([FromBody] string[] input)
    {
        float[] test = input.Select(float.Parse).ToArray();
        var inputTensor = new DenseTensor<float>(test, new[] { 1, input.Length });
        var inputs = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor("input", inputTensor) };
        using var results = _heartsession.Run(inputs);
        var output = results.First().AsEnumerable<float>().ToArray();
        return Ok(output);
    }


    [HttpPost("PredictCovid")]
    public ActionResult<float[]> PredictCovid([FromBody] string[] input)
    {
        float[] test = input.Select(float.Parse).ToArray();
        var inputTensor = new DenseTensor<float>(test, new[] { 1, input.Length });
        var inputs = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor("input", inputTensor) };
        using var results = _covidsession.Run(inputs);
        var output = results.First().AsEnumerable<float>().ToArray();
        return Ok(output);
    }
    
    
    [HttpPost("PredictDiabetes")]
    public ActionResult<float[]> PredictDiabetes([FromBody] string[] input)
    {
        float[] test = input.Select(float.Parse).ToArray();
        var inputTensor = new DenseTensor<float>(test, new[] { 1, input.Length });
        var inputs = new List<NamedOnnxValue> { NamedOnnxValue.CreateFromTensor("input", inputTensor) };
        using var results = _diabeticsession.Run(inputs);
        var output = results.First().AsEnumerable<float>().ToArray();
        return Ok(output);
    }





}