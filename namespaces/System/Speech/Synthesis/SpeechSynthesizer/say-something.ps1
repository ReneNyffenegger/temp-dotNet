add-type -assemblyName System.Speech
$say  = new-object  -typeName System.Speech.Synthesis.SpeechSynthesizer
$say.Speak('Hello World')
