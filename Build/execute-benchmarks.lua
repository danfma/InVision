-- BENCHMARKS
benchmarks = {
	"MathVector3.FiboMode.GameMathSafe",
	"MathVector3.FiboMode.GameMathSimd",
	"MathVector3.FiboMode.GameMathUnsafe",
	"MathVector3.FiboMode.MonoSimd",
	"MathVector3.FiboMode.OpenTK"
}

for key,value in ipairs(benchmarks) do
	print("Executing benchmark: " .. value)
	os.execute("..\\Benchmark\\" .. value .. "\\bin\\Debug\\" .. value .. ".exe > benchmark-" .. value .. ".txt")
end
