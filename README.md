# xworm
decompiled source-code of recent xworm campaigns


## how?

1. I found a recent sample on abuse.ch and analyzed it in dnSpy.
2. from there, I have deobfuscated the code and exported them.

## security?

I have included a YARA-Rule to detect xworm based on different parameters. Additionally, I have made xworm unable from executing, so that cybersecurity-researchers can safely take a look at the source-code.

## motivation?

Everything is for educational-purposes. Using xworm and deploying it in production is strictly prohibited and is illegal!
