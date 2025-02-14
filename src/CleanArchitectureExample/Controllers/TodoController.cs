using ApplicationLayer;
using CleanArchitectureExample.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureExample.Controllers
{
    public class TodoController(ITodoService todoService, ITodoPresenter todoPresenter) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await PrepareView();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTodoInputModel model)
        {
            await todoService.CreateTodo(model.Title);

            return await PrepareView();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteTodoInputModel model)
        {
            await todoService.DeleteTodo(model.Id);

            return await PrepareView();
        }

        private async Task<IActionResult> PrepareView() {
            var todos = await todoService.GetTodos();

            var viewModel = todoPresenter.CreateTodoViewModel(todos);

            return View("Index", viewModel);
        }
    }
}
