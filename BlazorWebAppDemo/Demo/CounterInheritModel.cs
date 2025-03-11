using Microsoft.AspNetCore.Components;

namespace BlazorWebAppDemo.Demo
{
    public class CounterInheritModel : ComponentBase
    {
        protected int currentCount = 0;
        protected void IncrementCount()
        {
            currentCount++;
        }
    }
}
