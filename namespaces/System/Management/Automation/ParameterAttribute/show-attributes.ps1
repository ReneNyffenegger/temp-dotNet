foreach ($prop in ([System.Management.Automation.ParameterAttribute].DeclaredProperties | sort-object Name) ) {
   "$($prop.Name) -- $($prop.PropertyType)"
}


DontShow -- bool -- Don't show in programming assisting tools like intellisense
EffectiveAction -- ExperimentAction -- 
ExperimentAction -- ExperimentAction -- 
ExperimentName -- string -- Short description (for example for a tool tip)
HelpMessage -- string --
HelpMessageBaseName -- string --
HelpMessageResourceId -- string --
Mandatory -- bool -- set to true to make parameter mandatory, otherwise, parameter is optional.
ParameterSetName -- string -- Name of parameter set that parameter belongs to. Default `ParameterAttribute.AllParameterSets`
Position -- int -- If not set, the paramter is a named parameter
ToHide -- bool -- ?
ToShow -- bool -- ?
ValueFromPipeline -- bool -- 
ValueFromPipelineByPropertyName -- bool -- if `true`: objects from the pipeline with an attribute that has the same name as the parameter provide the parameter's value
ValueFromRemainingArguments -- bool -- if `true`: remaining arguments create an array as value for the parameter
