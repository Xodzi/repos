using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace StackTests
{
    public class StackTests
    {
        [Theory]
        [InlineData(42, 42)]
        [InlineData("Hello", "Hello")]
        public void Push_AddItemToStack_SuccessfullyAdded(object item, object expected)
        {
            // Arrange
            NewStack<object> myStack = new NewStack<object>(5);

            // Act
            myStack.Push(item);

            // Assert
            Assert.Equal(expected, myStack.Peek());
        }

        [Fact]
        public void Push_AddToFullStack_ReturnsOverflowMessage()
        {
            // Arrange
            NewStack<int> myStack = new NewStack<int>(1);
            myStack.Push(42);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => myStack.Push(99));
            Assert.Equal(ex.Message, "Переполнение стека");
        }

        [Fact]
        public void Pop_AttemptToPopFromEmptyStack_ReturnsEmptyStackMessage()
        {
            // Arrange
            NewStack<int> myStack = new NewStack<int>(5);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => myStack.Pop());
            Assert.Equal(ex.Message, "Стек пуст");
        }

        [Theory]
        [InlineData(new int[] { 42 }, 42)]
        [InlineData(new int[] { 42, 99 }, 99)]
        public void Pop_PopFromStack_ReturnsExpectedItem(int[] initialItems, int expected)
        {
            // Arrange
            NewStack<int> myStack = new NewStack<int>(initialItems.Length);
            foreach (int item in initialItems)
            {
                myStack.Push(item);
            }

            // Act & Assert
            Assert.Equal(expected, myStack.Pop());
        }

        [Fact]
        public void Peek_AttemptToPeekEmptyStack_ReturnsEmptyStackMessage()
        {
            // Arrange
            NewStack<int> myStack = new NewStack<int>(5);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => myStack.Peek());
            Assert.Equal(ex.Message, "Стек пуст");
        }

        [Theory]
        [InlineData(new int[] { 42 }, 42)]
        [InlineData(new int[] { 42, 99 }, 99)]
        public void Peek_PeekStack_ReturnsExpectedItem(int[] initialItems, int expected)
        {
            // Arrange
            NewStack<int> myStack = new NewStack<int>(initialItems.Length);
            foreach (int item in initialItems)
            {
                myStack.Push(item);
            }

            // Act & Assert
            Assert.Equal(expected, myStack.Peek());
        }

        [Theory]
        [InlineData(new int[] { }, "Стек пуст.")]
        [InlineData(new int[] { 42 }, "Элементы стека: 42")]
        [InlineData(new int[] { 42, 99 }, "Элементы стека: 42 99")]
        public void PrintStack_PrintStack_ReturnsExpectedOutput(int[] initialItems, string expected)
        {
            // Arrange
            NewStack<int> myStack = new NewStack<int>(initialItems.Length);
            foreach (int item in initialItems)
            {
                myStack.Push(item);
            }

            // Act
           string printedStack = myStack.PrintStackTest();

            // Assert
            Assert.Contains(expected, printedStack);
        }

        [Fact]
        public void GeneralOperations_SequentialAdditionAndRemoval_OrderAndCorrectnessVerified()
        {
            // Arrange
            NewStack<int> myStack = new NewStack<int>(5);

            // Act
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);

            int poppedItem1 = myStack.Pop();
            int poppedItem2 = myStack.Pop();
            myStack.Push(4);
            int poppedItem3 = myStack.Pop();

            // Assert
            Assert.Equal(3, poppedItem1);
            Assert.Equal(2, poppedItem2);
            Assert.Equal(4, poppedItem3);
            Assert.Equal(1, myStack.Count);
        }

        [Fact]
        public void GeneralOperations_AddAndRemoveAtMaxCapacity_CorrectlyHandlesMaxCapacity()
        {
            // Arrange
            NewStack<int> myStack = new NewStack<int>(2);

            // Act
            myStack.Push(1);
            myStack.Push(2);

            // Assert
            Assert.Equal(2, myStack.Count);

            // Act
            int poppedItem1 = myStack.Pop();
            int poppedItem2 = myStack.Pop();

            // Assert
            Assert.Equal(2, poppedItem1);
            Assert.Equal(1, poppedItem2);
            Assert.Equal(0, myStack.Count);
        }

        [Fact]
        public void GeneralOperations_AddAfterPop_CorrectlyHandlesSubsequentAddition()
        {
            // Arrange
            NewStack<int> myStack = new NewStack<int>(3);

            // Act
            myStack.Push(1);
            myStack.Pop();
            myStack.Push(2);

            // Assert
            Assert.Equal(2, myStack.Peek());
            Assert.Equal(1, myStack.Count);



        }

    }
}